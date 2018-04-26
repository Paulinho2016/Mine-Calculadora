using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGUI.Classes
{
    enum Operadores { Vazio, Somar, Subtrair, Multiplicar, Dividir }

    class Executor
    {
        #region Declarações

        //Variaveis
        private static List<Control> Controles;
        private static double operando1, operando2;
        private static Operadores Operador = Operadores.Vazio;
        private static double Resultado;


        //Propriedades
        
        private static TextBox Display { get => ((TextBox)Controles.Find(x => x.Name.Equals("tbxDisplay1"))); }
        private static TextBox Memoria { get => ((TextBox)Controles.Find(x => x.Name.Equals("tbxDisplay2"))); }

        #endregion




        #region Métodos e Eventos

        /// <summary>
        /// Evento responsável por fazer todos os procedimentos necessários no carregamento.
        /// </summary>
        /// <param name="objeto">Parametro causador do disparo.</param>
        /// <param name="evento">Parametro que contém dados do evento.</param>
        public static void Inicializacao(object objeto, EventArgs evento)
        {
            Controles = new List<Control>();
            operando1 = 0;

            foreach (Control controle in ((Control)objeto).Controls)
            {
                Controles.Add(controle);

                if (controle is Panel)
                    foreach (Control item in controle.Controls)
                        Controles.Add(controle);
            }

            Display.Text = operando1.ToString();
        }


        public static void Fechar(object objeto, EventArgs evento) {
            //((Form)((Control)objeto).Parent.Parent).Close();
            Application.ExitThread();
        }


        public static void InserirNnumero(object objeto, EventArgs evento)
        {
            var NumeroAtual = ((Control)objeto).Text;

            if (Operador is Operadores.Vazio)
            {
                if (operando1.Equals(0) && !Display.Text.Equals("0,"))
                {
                    operando1 = double.Parse(NumeroAtual);
                    Display.Text = operando1.ToString();                 
                }
                else
                {
                    operando1 = double.Parse(Display.Text + NumeroAtual);
                    Display.Text = operando1.ToString();
                }
            }
            else
            {
                if (operando2.Equals(null) || operando2.Equals(0) && !Display.Text.Equals("0,"))
                {                    
                     operando2 = double.Parse(NumeroAtual);
                     Display.Text = operando2.ToString();
                }
                else
                {
                    operando2 = double.Parse(Display.Text + NumeroAtual);
                    Display.Text = operando2.ToString();
                }
            }
        }
        

        public static void DefinirOperador(object objeto, EventArgs evento)
        {
            if (Operador.Equals(Operadores.Vazio)) { 
                if (!operando1.Equals(0))
                {
                    switch (((Control)objeto).Text)
                    {
                        case "+":
                            Operador = Operadores.Somar;
                            break;

                        case "-":
                            Operador = Operadores.Subtrair;
                            break;

                        case "*":
                            Operador = Operadores.Multiplicar;
                            break;

                        case "/":
                            Operador = Operadores.Dividir;
                            break;

                        default:
                            break;
                    }

                    Memoria.Text = $"{ operando1 } { ((Control)objeto).Text } ";
                    Display.Text = "0";                
                }
            }
            else
            {
                Operar();
                operando1 = Resultado;

                switch (((Control)objeto).Text)
                {
                    case "+":
                        Operador = Operadores.Somar;
                        break;

                    case "-":
                        Operador = Operadores.Subtrair;
                        break;

                    case "*":
                        Operador = Operadores.Multiplicar;
                        break;

                    case "/":
                        Operador = Operadores.Dividir;
                        break;

                    default:
                        break;
                }

                Memoria.Text = $"{ operando1 } { ((Control)objeto).Text } ";
                Display.Text = "0";
            }
        }


        public static void Operacao(object objeto, EventArgs evento)
        {
            if(!operando1.Equals(0) && !operando2.Equals(0) && !Operador.Equals(Operadores.Vazio))
            {
                Operar();
                Memoria.Text += $" {operando2} = {Resultado}";
                Display.Text = Resultado.ToString();
            }
        }


        public static void Limpar(object objeto, EventArgs evento)
        {
            if (((Control)objeto).Text.Equals("C"))
            {
                operando1 = 0;
                operando2 = 0;
                //Operador = Operadores.Vazio;
                Display.Text = operando1.ToString();
            }
            else
            {
                Memoria.Text = string.Empty;
                operando1 = 0;
                operando2 = 0;
                Operador = Operadores.Vazio;
                Display.Text = operando1.ToString();
            }
        }


        static void Operar()
        {
            switch (Operador)
            {
                case Operadores.Somar:
                    Resultado = operando1 + operando2;
                    break;

                case Operadores.Subtrair:
                    Resultado = operando1 - operando2;
                    break;

                case Operadores.Multiplicar:
                    Resultado = operando1 * operando2;
                    break;

                case Operadores.Dividir:
                    Resultado = operando1 / operando2;
                    break;

                default:
                    break;
            }
        }


        public static void ManipularVirgula(object objeto, EventArgs evento)
        {
            if (!Display.Text.Contains(","))
                Display.Text += ",";
        }


        public static void BackSpace(object objeto, EventArgs evento)
        {
            if (Display.TextLength > 1)
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            else if (Display.TextLength.Equals(1) && !Display.Text.Equals("0"))
                Display.Text = "0";

        }

        #endregion
    }
}
