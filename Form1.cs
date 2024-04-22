using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraSimples
{
    public partial class Form1 : Form
    {
        // A quantidade de vírgulas.
        int qtdVirgulas;

        // Método construtor.
        public Form1()
        {
            InitializeComponent();
        }

        // Uma lista de opções.
        enum Operacoes
        {
            Soma,
            Subtrai,
            Multiplica,
            Divide,
            Nenhuma
        }

        static Operacoes ultimaOperacao = Operacoes.Nenhuma;

        private void buttonApaga_Click(object sender, EventArgs e)
        {
           textBoxDisplay.Clear();
           ultimaOperacao = Operacoes.Nenhuma;
           qtdVirgulas = 0;
        }

        private void buttonSubtrai_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Subtrai;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonSoma_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Soma;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
            qtdVirgulas = 0;
        }

        private void FazerCalculo(Operacoes ultimaOperacao)
        {
            // double é número real (com casas decimais).
            List<double> listaDeNumeros = new List<double>();
           
            // Estrutura de decisão switch-case.
            switch (ultimaOperacao)
            {
                case Operacoes.Soma:
                    listaDeNumeros = textBoxDisplay.Text.Split('+').Select(double.Parse).ToList();
                    // string é texto.
                    textBoxDisplay.Text = (listaDeNumeros[0] + listaDeNumeros[1]).ToString();
                    break;
                case Operacoes.Subtrai:
                    listaDeNumeros = textBoxDisplay.Text.Split('-').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (listaDeNumeros[0] - listaDeNumeros[1]).ToString();
                    break;
                case Operacoes.Multiplica:
                    listaDeNumeros = textBoxDisplay.Text.Split('X').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (listaDeNumeros[0] * listaDeNumeros[1]).ToString();
                    break;
                case Operacoes.Divide:
                    try
                    {
                        listaDeNumeros = textBoxDisplay.Text.Split('/').Select(double.Parse).ToList();
                        textBoxDisplay.Text = (listaDeNumeros[0] / listaDeNumeros[1]).ToString();
                    }
                    catch (DivideByZeroException) 
                    {
                        textBoxDisplay.Text = "Divisão por zero.";
                    }
                    break;
                case Operacoes.Nenhuma:
                    break;
                default:
                    break;
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
 
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Divide;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonMultiplica_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Multiplica;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonVirgula_Click(object sender, EventArgs e)
        {
            if (qtdVirgulas > 0)
            {
                return;
            }
            else
            {
                textBoxDisplay.Text += ",";
                // ZERAR quantidade de vírgulas ao pressionar
                // alguma operação.
                qtdVirgulas = 1;
            }
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text.Length > 0)
            {
                textBoxDisplay.Text = textBoxDisplay.Text.Remove(textBoxDisplay.Text.Length - 1, 1);
                if (textBoxDisplay.Text.EndsWith(","))
                {
                    qtdVirgulas = 0;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxDisplay.Text);
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            // Se ultima operação for DIFERENTE de nenhuma.
            if (ultimaOperacao != Operacoes.Nenhuma)
            {
                FazerCalculo(ultimaOperacao);
            }
            // Limpa a memória da nossa calculadora.
            ultimaOperacao = Operacoes.Nenhuma;
        }

        private void buttonDarkMode_Click(object sender, EventArgs e)
        {
           
            if (BackColor == Color.Black)
            {
                BackColor = Color.White;

            }
            else
            {
                BackColor = Color.Black;
            }
        }
    }
}
