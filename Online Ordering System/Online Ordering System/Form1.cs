using System;
using System.Windows.Forms;

namespace Online_Ordering_System
{
    public partial class Online_Order : Form
    {
        string Operation;
        double FirstNum, SeconedNum, Answer, iTax = 17.5;

        double jeans, Tshirt, Jacket;

        double ConvertedCurrency,  USD = 0.0635, EUR = 0.0521, JPY = 6.5741, ARS = 5.2908,
            GBP = 0.0469;


        private void Operators_Click(object sender, EventArgs e)
        {
            Button op = (Button)sender;
            FirstNum = Double.Parse(Display.Text);
            Display.Text = "";
            Operation = op.Text;
            Calculated.Text = System.Convert.ToString(FirstNum) + " " + Operation;
        }
        //backspace
        private void button1_Click(object sender, EventArgs e)
        {
            if (Display.Text.Length > 0)
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1, 1);
            }
        }
        //dot
        private void button14_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (num.Text == ".")
            {
                Display.Text = Display.Text + num.Text;
            }
        }
        
        private void btnCurrency_Click(object sender, EventArgs e)
        {
            btnCurrency.Visible = false;
            Close.Visible = true;
            Convert.Visible = true;
        }


        private void button27_Click(object sender, EventArgs e)
        {
            btnCurrency.Visible = true;
            Close.Visible = false;
            Convert.Visible = false;
        }
        //Convert
        private void button17_Click(object sender, EventArgs e)
        {
            ConvCurrency.Text = System.Convert.ToString(ConvertedCurrency);
        }
        //reset
        private void button21_Click(object sender, EventArgs e)
        {
            DateTime iDate = DateTime.Now;
            order_DateTextBox.Text = iDate.ToString("dd/MM/yyyy");
            order_TimeTextBox.Text = iDate.ToString("hh:mm:ss:tt");
            customer_NameTextBox.Text = "";
            customer_PhoneTextBox.Text = "";
            order_Ref_NoTextBox.Text = "0";
            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";
            txtReceipt.Text = "";
            unit_Price1TextBox.Text = "0";
            unit_Price2TextBox.Text = "0";
            unit_Price3TextBox.Text = "0";
            sub_Total1TextBox.Text = "";
            sub_Total2TextBox.Text = "";
            sub_Total3TextBox.Text = "";
            net_Sub_TotalTextBox.Text = "";
            net_TotalTextBox.Text = "";
            taxTextBox.Text = "";
        }

        
        //calculator
        private void button23_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        //order
        private void button25_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        //reciept
        private void button24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;

            txtReceipt.AppendText("\t\t\t" + "    Shop");
            txtReceipt.AppendText("\t\t\t" + "========================================================" + Environment.NewLine);
            txtReceipt.AppendText(" " + Environment.NewLine);
            txtReceipt.AppendText("Name : " + "\t" + customer_NameTextBox.Text + "\t" + "Phone No : " + customer_PhoneTextBox.Text + "\t" + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "Order_Date:" + "\t" + order_DateTextBox.Text + "\t" + "Order_Time:" + "\t" + order_TimeTextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "Item Type:     " + "\t" + "Qty" + "\t   " + "Unit Price" + "\t   " + " Sub Total " + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "Jeans" + "\t" + qty1TextBox.Text + "\t" + unit_Price1TextBox.Text + "\t" + "\t" + sub_Total1TextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "T-shirt" + "\t" + qty2TextBox.Text + "\t" + unit_Price2TextBox.Text + "\t" + "\t" + sub_Total2TextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "Jacket" + "\t" + qty3TextBox.Text + "\t" + unit_Price3TextBox.Text + "\t" + "\t" + sub_Total3TextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "\t\t\t" + "Order Sub Total : " + "\t" + net_Sub_TotalTextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "\t\t\t" + " Tax on Order " + "\t" + taxTextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "\t\t\t" + " Net Total:" + "\t" + net_TotalTextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + " ======================================================================" + Environment.NewLine);
            txtReceipt.AppendText("\t\t\t" + "  Shop Receipt " + Environment.NewLine);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DateTime iDate = DateTime.Now;
            order_DateTextBox.Text = iDate.ToString("dd/MM/yyyy");
            order_TimeTextBox.Text = iDate.ToString("hh:mm:ss:tt");
            tabControl1.SelectedTab = tabPage2;
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.order_SystemDataSet);
            bindingNavigatorAddNewItem.PerformClick();
        }

        private void tableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.order_SystemDataSet);

        }

        private void tableBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.order_SystemDataSet);

        }
        //total
        private void button20_Click(object sender, EventArgs e)
        {
            Double jeans, Tshirt, Jacket, unitprice1, unitprice2, unitprice3, NetTax;

            jeans = Double.Parse(qty1TextBox.Text);
            Tshirt = Double.Parse(qty2TextBox.Text);
            Jacket = Double.Parse(qty3TextBox.Text);

            unitprice1 = Double.Parse(unit_Price1TextBox.Text);
            unitprice2 = Double.Parse(unit_Price2TextBox.Text);
            unitprice3 = Double.Parse(unit_Price3TextBox.Text);

            jeans = jeans * unitprice1;
            Tshirt = Tshirt * unitprice2;
            Jacket = Jacket * unitprice3;

            sub_Total1TextBox.Text = System.Convert.ToString(jeans);
            sub_Total2TextBox.Text = System.Convert.ToString(Tshirt);
            sub_Total3TextBox.Text = System.Convert.ToString(Jacket);

            net_Sub_TotalTextBox.Text = System.Convert.ToString(jeans + Tshirt + Jacket);
            NetTax = ((jeans + Tshirt + Jacket) * iTax) / 100;
            taxTextBox.Text = System.Convert.ToString(NetTax);
            net_TotalTextBox.Text = System.Convert.ToString(NetTax + (jeans + Tshirt + Jacket));

            unit_Price1TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price1TextBox.Text));
            unit_Price2TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price2TextBox.Text));
            unit_Price3TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price3TextBox.Text));
            sub_Total1TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total1TextBox.Text));
            sub_Total2TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total2TextBox.Text));
            sub_Total3TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total3TextBox.Text));
            net_Sub_TotalTextBox.Text = String.Format("{0:C}", Double.Parse(net_Sub_TotalTextBox.Text));
            net_TotalTextBox.Text = String.Format("{0:C}", Double.Parse(net_TotalTextBox.Text));
            taxTextBox.Text = String.Format("{0:C}", Double.Parse(taxTextBox.Text));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ConvertedCurrency = Double.Parse(Display.Text);
                    break;
                case 1:
                    ConvertedCurrency = Double.Parse(Display.Text) * USD;
                    break;
                case 2:
                    ConvertedCurrency = Double.Parse(Display.Text) * JPY;
                    break;
                case 3:
                    ConvertedCurrency = Double.Parse(Display.Text) * GBP;
                    break;
                case 4:
                    ConvertedCurrency = Double.Parse(Display.Text) * EUR;
                    break;
                case 5:
                    ConvertedCurrency = Double.Parse(Display.Text) * ARS;
                    break;
            }
        }
        //clear
        private void button3_Click(object sender, EventArgs e)
        {
            Display.Text = "";
            Calculated.Text = "";
            Display.Text = "0";
        }

        //equal
        private void button15_Click(object sender, EventArgs e)
        {
            Calculated.Text = "";
            SeconedNum = Double.Parse(Display.Text);
            switch (Operation)
            {
                case "+":
                    Answer = (FirstNum + SeconedNum);
                    Display.Text = System.Convert.ToString(Answer);
                    break;
                case "-":
                    Answer = (FirstNum - SeconedNum);
                    Display.Text = System.Convert.ToString(Answer);
                    break;
                case "*":
                    Answer = (FirstNum * SeconedNum);
                    Display.Text = System.Convert.ToString(Answer);
                    break;
                case "/":
                    Answer = (FirstNum / SeconedNum);
                    Display.Text = System.Convert.ToString(Answer);
                    break;
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = num.Text;
            }
            else { Display.Text += num.Text; }
        }

        public Online_Order()
        {
            InitializeComponent();
        }



        private void Online_Order_Load(object sender, EventArgs e)
        {
            DateTime iDate = DateTime.Now;
            order_DateTextBox.Text = iDate.ToString("dd/MM/yyyy");
            order_TimeTextBox.Text = iDate.ToString("hh:mm:ss:tt");
            Close.Visible = false;
            Convert.Visible = false;

            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";
            unit_Price1TextBox.Text = "0";
            unit_Price2TextBox.Text = "0";
            unit_Price3TextBox.Text = "0";
            bindingNavigatorAddNewItem.PerformClick();
        }
    }
}
