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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ErofeevSession2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Массивы
        List<Material> materials = new List<Material>();
        List<MaterialType> typematerial = new List<MaterialType>();
        List<String> sortlist = new List<string>()
        {
            //Вывод текста по сортировки в ComboBox CmdSort
            "Без сортировки",
            "По возрастанию наименования",
            "По убыванию наименования",
            "По возрастанию цены",
            "По убыванию цены",
            "По возрастанию остатка",
            "По убыванию остатка",
        };
        public MainWindow()
        {
            InitializeComponent();
            // Работа с фильтром
            // Добаление данных в ComboBox
            typematerial = Connect.con.MaterialType.ToList();
            // Добавляем в строку все типы
            typematerial.Insert(0, new MaterialType { Title = "Все типы материалов" });

            //Работа с мвссивом typematerial
            CmdFilter.ItemsSource = typematerial;
            //Перебор индексов от 0 в CmdFilter
            CmdFilter.SelectedIndex = 0;

            //Работа с мвссивом sortlist
            CmdSort.ItemsSource = sortlist;
            //Перебор индексов от 0 в CmdSort
            CmdSort.SelectedIndex = 0;

            //Обращение к методу
            Load();
        }

        //Метод для поиска
        private void Search()
        {
            //Подключение к массиву
            materials = Connect.con.Material.ToList();

            //TextBox не равен пустате
            if (TB1.Text != String.Empty)
            {
                //TextBox не равен "Введите для поиска"
                if (TB1.Text != "Введите для поиска")
                {
                    //Обращение к методу Load
                    Load();
                    materials = materials.Where(x => x.Title.ToLower().Contains(TB1.Text.ToLower())).ToList(); //ToLower - Возможность происка по заглавной и сторочной букве
                    lst.ItemsSource = materials;
                    if (materials.Count == 0)
                    {
                        TBNullSearch.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        TBNullSearch.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                Load();
                TBNullSearch.Visibility = Visibility.Hidden;
            }
        }

        // Метод для сортировки и фильтрации
        private void Load()
        {
            
            materials = Connect.con.Material.ToList();

            //Сортировка
            switch (CmdSort.SelectedIndex)
            {
                case 0:
                    materials = Connect.con.Material.ToList(); //Без сортировки
                    break;
                case 1:
                   materials = materials.OrderBy(i => i.Title).ToList(); //По возрастанию наименования
                    break;
                case 2:
                    lst.ItemsSource = materials.OrderByDescending(i => i.Title).ToList(); //По убыванию наименования
                    break;
                case 3:
                    materials = materials.OrderBy(i => i.Cost).ToList(); //По возрастанию цены
                    break;
                case 4:
                    lst.ItemsSource = materials.OrderByDescending(i => i.Cost).ToList(); //По убыванию цены
                    break;
                case 5:
                    materials = materials.OrderBy(i => i.CountInStock).ToList(); //По возрастанию остатка
                    break;
                case 6:
                    lst.ItemsSource = materials.OrderByDescending(i => i.CountInStock).ToList(); //По убыванию остатка
                    break;
            }

            //Фильтрация
            if (CmdFilter.SelectedIndex != 0)
            {
                materials = materials.Where(i => i.MaterialType.ID == CmdFilter.SelectedIndex).ToList();
            }

            //Подгрузка материалов в ListBox
            lst.ItemsSource = materials;
        }

        private void TB1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TB1.Text == "Введите для поиска")
                TB1.Text = "";
        }

        private void TB1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TB1.Text == "")
                TB1.Text = "Введите для поиска";
        }

        //Событие на закрытие приложения
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //События ссылающие на метод
        private void CmdFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
            Search();
        }

        private void CmdSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
            Search();
        }

        private void TB1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChangeMaterial cm = new ChangeMaterial();
            cm.ShowDialog();
        }

        private void lst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeMaterial cn = new ChangeMaterial(lst.SelectedItem as Material);
            cn.ShowDialog();
        }
    }
}
