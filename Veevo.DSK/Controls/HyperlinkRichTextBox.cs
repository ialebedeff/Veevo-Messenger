using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Veevo.DSK.Controls
{
    public class HyperlinkRichTextBox : RichTextBox
    {

        #region CustomText Dependency Property

        public static readonly DependencyProperty CustomTextProperty = DependencyProperty.Register("CustomText", typeof(string), typeof(HyperlinkRichTextBox),
            new PropertyMetadata(string.Empty, CustomTextChangedCallback), CustomTextValidateCallback);

        public string CustomText
        {
            get => (string)GetValue(CustomTextProperty);
            set => SetValue(CustomTextProperty, value);
        }

        private static void CustomTextChangedCallback(
                    DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ((HyperlinkRichTextBox)obj).Document = GetCustomDocument(e.NewValue as string);
        }

        private static bool CustomTextValidateCallback(object value) => value != null;
        #endregion

        private const string HttpPrefix = "http://";

        private static readonly Regex LinkRegex =
                    new Regex(
                @"([--:А-Яа-я\w?@%&+~#=]*\.[a-zа-я]{2,4}\/{0,2})((?:[?&](?:[А-Яа-я\w]+)=(?:[А-Яа-я\w]+))+|[--:А-Яа-я\w?@%&+~#=]+)?",
                RegexOptions.Compiled);

        private static readonly Regex PrefixRegex =
            new Regex("^(http|ftp)(s)?", RegexOptions.Compiled);

        private static FlowDocument GetCustomDocument(string text)
        {
            var document = new FlowDocument();
            var para = new Paragraph { Margin = new Thickness(0) };

            var linksMatches = LinkRegex.Matches(text);


            if (linksMatches.Count == 0)
            {
                para.Inlines.Add(text);
            }
            else
            {
                Match lastMatch = null;
                foreach (Match linksMatch in linksMatches)
                {
                    var previousText = GetPreviousText(text, lastMatch, linksMatch);

                    para.Inlines.Add(previousText);

                    var link = CreateLink(linksMatch.Value);
                    para.Inlines.Add(link);
                    lastMatch = linksMatch;
                }
                var tail = GetPreviousText(text, lastMatch);
                para.Inlines.Add(tail);
            }

            document.Blocks.Add(para);
            return document;
        }

        private static Hyperlink CreateLink(string url)
        {
            var link = new Hyperlink
            {
                IsEnabled = true
            };

            link.Inlines.Add(url);

            link.NavigateUri = PrefixRegex.IsMatch(url)
                ? new Uri(url)
                : new Uri($"{HttpPrefix}{url}");

            link.RequestNavigate += (sender, args) => Process.Start(args.Uri.ToString());

            return link;
        }

        private static string GetPreviousText(string text, Capture lastMatch, Capture currentMatch = null)
        {
            var startIndex = lastMatch != null ? lastMatch.Index + lastMatch.Length : 0;

            return currentMatch != null
                ? text.Substring(startIndex, currentMatch.Index - startIndex)
                : text.Substring(startIndex);
        }
    }
}
