namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_1_Click(object sender, EventArgs e)
        {
            long result = await LoopAsync();

            //Task task = Task.Run(() =>
            //{
            //    for (long i = 0; i < 9999999999; i++)
            //    {
            //        result += i;
            //    }
            //});

            //await task;

            lbl_1.Text = result.ToString();
        }

        private async Task<long> LoopAsync()
        {
            long result = 0;

            Task task = Task.Run(() =>
            {
                for (long i = 0; i < 999999999; i++) 
                {
                    result += i;
                
                }
            });

            await task;

            return result;
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            lbl_2.Text = "Hello P235";
        }
    }
}