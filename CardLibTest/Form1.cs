using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardLibrary;

namespace CardLibTest
{
    public partial class Form1 : Form
    {
        Deck _deck;
        Hand _hand;

        public Form1()
        {
            InitializeComponent();

            _hand = new Hand();
        }

        private async void btnDeck_Click(object sender, EventArgs e)
        {
            _deck = await Deck.InitializeDeck(chkJokers.Checked);
            MessageBox.Show("Deck is ready");
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (_deck != null)
            {
                Card card = _deck.Draw();
                _hand.Add(card);
                label1.Text = card.ToString();
            }
        }
    }
}
