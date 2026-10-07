using HorizonShopping.Core.Enums;

namespace HorizonShopping.WinForms
{
    static class FuncionesInterfaz
    {
        static public void RellenarComboBoxSecciones(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            foreach(Seccion seccion in Enum.GetValues(typeof(Seccion)))
            {
                comboBox.Items.Add(seccion);
            }
        }
    }
}
