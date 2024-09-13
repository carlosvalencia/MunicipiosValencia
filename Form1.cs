using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipiosValencia
{
	  public partial class Form1 : Form
  {

    private GeoMuni geo;

    public Form1()
    {
      InitializeComponent();

      geo = new GeoMuni();

      listProvincias.ValueMember = "id";
      listProvincias.DisplayMember = "nom";
      listProvincias.DataSource = geo.Provincias();
      listProvincias.SelectedIndex = -1;

      listComarcas.ValueMember = "id";
      listComarcas.DisplayMember = "nom";
      listComarcas.DataSource = geo.Comarcas();
      listComarcas.SelectedIndex = -1;
    }

    private void listProvincias_SelectedIndexChanged(object sender, EventArgs e)
    {

      if (this.IsHandleCreated)
      {
        List<ItemGeo> items = geo.MunicipiosEnProvincia((int)listProvincias.SelectedValue);
        label3.Text = listProvincias.Text + ", " + items.LongCount().ToString() + " municipos";
        CambiaListaMunicipios(items);
      }
    }

    private void listComarcas_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.IsHandleCreated)
      {
        List<ItemGeo> items = geo.MunicipiosEnComarca((int)listComarcas.SelectedValue);
        label3.Text = listComarcas.Text + ", " + items.LongCount().ToString() + " municipos";
        CambiaListaMunicipios(items);
      }
    }

    private void CambiaListaMunicipios(List<ItemGeo> items)
    {
      listMunicipios.ValueMember = "id";
      listMunicipios.DisplayMember = "nom";
      listMunicipios.DataSource = items;
      listMunicipios.SelectedIndex = -1;
    }

    private void botTodos_Click(object sender, EventArgs e)
    {
      label3.Text = "Todos los municipios ( 542 )";

      listMunicipios.ValueMember = "id";
      listMunicipios.DisplayMember = "nom";
      listMunicipios.DataSource = geo.Municipios();
      listMunicipios.SelectedIndex = -1;
    }

    private void listMunicipios_Click(object sender, EventArgs e)
    {
      if (listMunicipios.Items.Count > 0)
      {
        string mensage = "Municipio : " + ((ItemGeo)listMunicipios.SelectedItem).nom + Environment.NewLine + "Código : " + ((ItemGeo)listMunicipios.SelectedItem).id.ToString();
        MessageBox.Show(mensage, "Información del municipio selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

    }

  }
}
