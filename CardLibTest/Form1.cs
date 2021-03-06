﻿using System;
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

            // Subscribe to the Draw event of the Hand class.
            _hand.Draw += _hand_Draw;
        }

        /// <summary>
        /// This method will handle functionality of the Hand object's Draw event.
        /// Write Card information to GUI when the Draw event is raised.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _hand_Draw(object sender, EventArgs e)
        {
            MessageBox.Show("A card was drawn");
        }

        private async void btnDeck_Click(object sender, EventArgs e)
        {
            // Await the asynchronous InitializeDeck method in order to return control to the GUI while it is executing
            _deck = await Deck.InitializeDeckAsync(chkJokers.Checked);
            MessageBox.Show("Deck is ready");
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (_deck != null)
            {
                Card card = _hand.DrawFromDeck(_deck);
                label1.Text = card.ToString();
            }
        }
    }
}
