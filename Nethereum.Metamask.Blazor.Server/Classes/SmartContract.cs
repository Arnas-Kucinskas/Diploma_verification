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
		public string functionName { get; set; } = "StoreHashes";

	}
}
