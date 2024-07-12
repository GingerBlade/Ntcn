using ErofeevSession2.ClassConnect;
using ErofeevSession2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ErofeevSession2
{
    /// <summary>
    /// Interaction logic for ChangeMaterial.xaml
    /// </summary>
    public partial class ChangeMaterial : Window
    {
        private bool isEdit;
        private Material editmaterial;

        public ChangeMaterial()
        {
            InitializeComponent();

            isEdit = false;
            cmb.ItemsSource = Connect.con.MaterialType.ToList();
            cmb.DisplayMemberPath = "Title";
            cmb.SelectedIndex = 0;
        }
        public ChangeMaterial(Material material)
        {
            InitializeComponent();
            editmaterial = material;
            isEdit = true;
            cmb.ItemsSource = Connect.con.MaterialType.ToList();
            cmb.DisplayMemberPath = "Title";

            text1.Text = material.Title;
            cmb.SelectedIndex = (int)(material.MaterialTypeID - 1);
            text2.Text = material.CountInStock.ToString();
            text3.Text = material.Unit.ToString();
            text4.Text = material.CountInPack.ToString();
            text5.Text = material.MinCount.ToString();
            text6.Text = material.Cost.ToString();
            text7.Text = material.Description;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isEdit)
            {
                Material addMaterial = new Material();

                addMaterial.Title = text1.Text;
                addMaterial.MaterialTypeID = cmb.SelectedIndex + 1;
                addMaterial.CountInStock = Convert.ToInt32(text2.Text);
                addMaterial.Unit = text3.Text;
                addMaterial.CountInPack = Convert.ToInt32(text4.Text);
                addMaterial.MinCount = Convert.ToInt32(text5.Text);
                addMaterial.Cost = Convert.ToDecimal(text6.Text);
                addMaterial.Description = text7.Text;
                Connect.con.Material.Add(addMaterial);
                Connect.con.SaveChanges();

                MessageBox.Show("Данные добавлены");
                Close();
            }
            else if (isEdit)
            {
                
                editmaterial.Title = text1.Text;
                editmaterial.MaterialTypeID = cmb.SelectedIndex + 1;
                editmaterial.CountInStock = Convert.ToInt32(text2.Text);
                editmaterial.Unit = text3.Text;
                editmaterial.CountInPack = Convert.ToInt32(text4.Text);
                editmaterial.MinCount = Convert.ToInt32(text5.Text);
                editmaterial.Cost = Convert.ToDecimal(text6.Text);
                editmaterial.Description = text7.Text;

                Connect.con.SaveChanges();

                MessageBox.Show("Данные изменены");
                Close();
            }
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
