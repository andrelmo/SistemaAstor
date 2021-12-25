using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var _frmListaUsuarios = new FormListarUsuario();

            try
            {
                _frmListaUsuarios.ShowDialog();
            }
            finally
            {
                _frmListaUsuarios.Close();
            }
        }

        private void toolStripMenuItemTipoBeneficios_Click(object sender, EventArgs e)
        {
            using var _frmListaTipoBeneficios = new FormListarTipoBeneficios();

            try
            {
                _frmListaTipoBeneficios.ShowDialog();
            }
            finally
            {
                _frmListaTipoBeneficios.Close();
            }
        }

        private void toolStripMenuItemFamilia_Click(object sender, EventArgs e)
        {
            using var _frmListarFamilia = new FormListarFamilia();

            try
            {
                _frmListarFamilia.ShowDialog();
            }
            finally
            {
                _frmListarFamilia.Close();
            }
        }
    }
}