using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Veevo.DSK.ViewModels.Commands;
using Veevo.Kernel.API;

namespace Veevo.DSK.ViewModels
{
    internal class MessengerViewModel : MessengerPropertiesViewModel
    {
        public MessengerViewModel()
        {
            CheckUpdatesTask = CheckUpdatesAsync();
        }

        public Task CheckUpdatesTask { get; set; }
        public async Task CheckUpdatesAsync()
        {
            while (true)
            {
                var updatesResponse = await VeevoAPI.GetUpdates();
                if (updatesResponse.Updates != null)
                {
                    MessageBox.Show(JsonConvert.SerializeObject(updatesResponse.Updates));
                }
                else
                {
                    MessageBox.Show(updatesResponse.Status.ToString());
                    MessageBox.Show(updatesResponse.IsSuccess.ToString());
                }
                await Task.Delay(1000);
            }
        }
    }
}
