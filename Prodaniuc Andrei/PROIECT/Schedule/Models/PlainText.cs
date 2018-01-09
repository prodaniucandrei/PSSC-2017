﻿using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlainText
    {
        private string _text;
        public string Text { get { return _text; } }

        public PlainText(string text)
        {
            //Contract.Requires<ArgumentNullException>(text != null, "text");
            //Contract.Requires<EmptyArgumentException>(!string.IsNullOrEmpty(text), "text");

            _text = text;
        }

        #region override object
        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            var nume = (PlainText)obj;
            return Text.Equals(nume.Text);
        }

        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }
        #endregion
    }
}
