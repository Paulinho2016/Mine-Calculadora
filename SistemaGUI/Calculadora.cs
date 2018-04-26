using SistemaGUI.Classes;
using System;
using System.Windows.Forms;

namespace SistemaGUI
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();

            Load += new EventHandler(Executor.Inicializacao);
            btnFechar.Click += new EventHandler(Executor.Fechar);

            btn0.Click += new EventHandler(Executor.InserirNnumero);
            btn1.Click += new EventHandler(Executor.InserirNnumero);
            btn2.Click += new EventHandler(Executor.InserirNnumero);
            btn3.Click += new EventHandler(Executor.InserirNnumero);
            btn4.Click += new EventHandler(Executor.InserirNnumero);
            btn5.Click += new EventHandler(Executor.InserirNnumero);
            btn6.Click += new EventHandler(Executor.InserirNnumero);
            btn7.Click += new EventHandler(Executor.InserirNnumero);
            btn8.Click += new EventHandler(Executor.InserirNnumero);
            btn9.Click += new EventHandler(Executor.InserirNnumero);

            btnVirgula.Click += new EventHandler(Executor.ManipularVirgula);

            btnAdicao.Click += new EventHandler(Executor.DefinirOperador);
            btnSubtracao.Click += new EventHandler(Executor.DefinirOperador);
            btnMultiplicacao.Click += new EventHandler(Executor.DefinirOperador);
            btnDivisao.Click += new EventHandler(Executor.DefinirOperador);

            btnBackSpace.Click += new EventHandler(Executor.BackSpace);
            btnIgual.Click += new EventHandler(Executor.Operacao);
            btnZerar.Click += new EventHandler(Executor.Limpar);
            btnLimpar.Click += new EventHandler(Executor.Limpar);            
        }
    }
}
