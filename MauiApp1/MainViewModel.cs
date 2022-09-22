using Binance.Net.Clients;
using Binance.Net.Objects;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public Ticker ticker;

        [ObservableProperty]
        public decimal holdingsAmount;

        public MainViewModel()
        {
            var socketClient = new BinanceSocketClient(new BinanceSocketClientOptions { });

            socketClient.SpotStreams.SubscribeToBookTickerUpdatesAsync("BTCUSDT", data => {

                Ticker = new Ticker
                {
                    AskPrice = $"${data.Data.BestAskPrice.ToString("N2")}",
                    BidPrice = $"${data.Data.BestBidPrice.ToString("N2")}",
                    HoldingsValue = (HoldingsAmount * data.Data.BestBidPrice).ToString()
                };

            });

            socketClient.UnsubscribeAllAsync();

        }
    }
}
