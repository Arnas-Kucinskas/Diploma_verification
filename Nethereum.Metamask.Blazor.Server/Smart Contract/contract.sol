pragma solidity 0.6.4;

contract EventStorage
{
    event StoreEvent(bytes32[]  dataHash) ;
    event FallBackCalled(address sender);
    address public owner;

    constructor() public
    {
        owner = msg.sender;
    }
    modifier onlyOwner () 
    {
        require(msg.sender == owner);
        _;
    }
    
    function StoreHashes(bytes32[] calldata hashArray) external onlyOwner
    {
        emit StoreEvent(hashArray);
    }

    fallback () external
    {
        emit FallBackCalled(msg.sender);
    }

    function DeleteContract(address payable receiver) external onlyOwner
    {
        selfdestruct(receiver);
    }

    function ChangeOwner (address newOwner) external onlyOwner
    {
        owner = newOwner;
    }
    //In case of forceful ether transfer
    function ClearCurrency(address payable adr) external  onlyOwner 
    {
        adr.transfer(address(this).balance);
    }

}