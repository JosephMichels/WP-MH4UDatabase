using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MH4U_Database.Controls
{
    /// <summary>
    /// A version of the ContentControl that works with the ContentTemplateSelector.
    /// </summary>
    public class CompositionControl : ContentControl
    {
        /// <summary>
        /// Invoked when the value of the Content property changes. 
        /// </summary>
        /// <param name="oldContent">The old value of the Content property.</param>
        /// <param name="newContent">The new value of the Content property.</param>
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            // There is a bug in the standard content control that trashes the value passed into the SelectTemplateCore method.  This is a
            // work-around that allows the same basic structure and can hopefully be replaced when the bug is fixed.  Basically take the new content
            // and figure out what template should be used with it based on the structure of the template selector.
            DataTemplateSelector dataTemplateSelector = this.ContentTemplateSelector as DataTemplateSelector;
            if (dataTemplateSelector != null)
            {
                this.ContentTemplate = dataTemplateSelector.SelectTemplate(newContent, null);
            }

            // Allow the base class to handle the rest of the call.
            base.OnContentChanged(oldContent, newContent);
        }
    }
}
