using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nethereum.Metamask.Blazor.Server.Classes
{
    public class SmartContract
    {
		public string abi { get; set; } =
		 @"[
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': 'newOwner',
				'type': 'address'
			}
		],
		'name': 'ChangeOwner',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address payable',
				'name': 'receiver',
				'type': 'address'
			}
		],
		'name': 'DeleteContract',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [],
		'stateMutability': 'nonpayable',
		'type': 'constructor'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': false,
				'internalType': 'address',
				'name': 'sender',
				'type': 'address'
			}
		],
		'name': 'FallBackCalled',
		'type': 'event'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': false,
				'internalType': 'bytes32[]',
				'name': 'dataHash',
				'type': 'bytes32[]'
			}
		],
		'name': 'StoreEvent',
		'type': 'event'
	},
	{
		'inputs': [
			{
				'internalType': 'bytes32[]',
				'name': 'hashArray',
				'type': 'bytes32[]'
			}
		],
		'name': 'StoreHashes',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'stateMutability': 'nonpayable',
		'type': 'fallback'
	},
	{
		'inputs': [],
		'name': 'owner',
		'outputs': [
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	}
]";
		public string address { get; set; } = "0x3c96A679dC4713599b4EDe9F2609770782FCc023";
		//public string address { get; set; } = "0x9E6bd5A4C2453b7dE7642E198bC7C8c3Cc99E300";

		public string functionName { get; set; } = "StoreHashes";
		public string infuraURL { get; set; } = "https://ropsten.infura.io/v3/75230d7a7f1547fcbb12f3707a6bbe44";

	}
}
