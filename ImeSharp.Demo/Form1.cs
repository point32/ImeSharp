﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImeSharp.Demo
{
    public partial class Form1 : Form
    {
        private string _inputContent = string.Empty;

        private void OnTextInput(char character)
        {
            switch (character)
            {
                case '\b':
                    if (_inputContent.Length > 0)
                        _inputContent = _inputContent.Remove(_inputContent.Length - 1, 1);
                    break;
                case '\r':
                    _inputContent = "";
                    break;
                default:
                    _inputContent += character;
                    break;
            }

            textBoxResult.Text = _inputContent;
        }

        private void OnTextComposition(IMEString compositionText, int cursorPosition, IMEString[] candidateList, int candidatePageStart, int candidatePageSize, int candidateSelection)
        {
            var str = compositionText.ToString();
            str = str.Insert(cursorPosition, "|");
            labelComp.Text = str;

            string candidateText = string.Empty;

            for (int i = 0; candidateList != null && i < candidateList.Length; i++)
                candidateText += string.Format("  {2}{0}.{1}\r\n", i + 1, candidateList[i], i == candidateSelection ? "*" : "");

            textBoxCandidates.Text = candidateText;

            InputMethod.SetTextInputRect(labelComp.Location.X + labelComp.Size.Width, labelComp.Location.Y, 0, labelComp.Size.Height);
        }

        public Form1()
        {
            InitializeComponent();

            CenterToScreen();

            Application.Idle += Application_Idle;
            KeyDown += Form1_KeyDown;

            InputMethod.Initialize(this.Handle, false);
            InputMethod.TextInputCallback = OnTextInput;
            InputMethod.TextCompositionCallback = OnTextComposition;

            //InputMethod.TextInput += (s, e) =>
            //{
            //    OnTextInput(e.Character);
            //};

            //InputMethod.TextComposition += (s, e) =>
            //{
            //    OnTextComposition(e.CompositionText, e.CursorPosition, e.CandidateList, e.CandidatePageStart, e.CandidatePageSize, e.CandidateSelection);
            //};
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            FakeDraw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                InputMethod.Enabled = !InputMethod.Enabled;
        }

        private void FakeDraw()
        {
        }

    }
}
