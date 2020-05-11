using System;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Numerics;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;
using Nethereum.ABI.Decoders;
using Nethereum.ABI;
using iText;
using iText.Kernel.Pdf;
using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Security.Cryptography;
using Nethereum.Hex.HexTypes;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Hex.HexConvertors.Extensions;
using System.Timers;
using Nethereum.Contracts;
using System.Linq;

namespace Nethereum.Metamask.Blazor.Server.Classes
{
    public class EthereumLib
    {
        public string infuraURL { get; set; } = "https://ropsten.infura.io/v3/75230d7a7f1547fcbb12f3707a6bbe44";

        public EthereumLib()
        {

        }

        public async Task<Dictionary<string, long>> GetConfirmations(Dictionary<string, long> txnDict)
        {
            var web3 = new Web3.Web3(infuraURL);
            Dictionary<string, long> tmpTxnDict = new Dictionary<string, long>();

            foreach (var item in txnDict)
            {
                var transaction = await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(item.Key);
                var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                long confirmations = (long)(latestBlockNumber.Value - transaction.BlockNumber);
                tmpTxnDict.Add(item.Key, confirmations);
            }
            return tmpTxnDict;
        }
    }
}
