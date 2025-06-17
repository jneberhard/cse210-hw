using System;

class Program
{
    static void Main(string[] args)
    {
        Coin myQuarter = new Quarter();
        Coin myDime = new Dime();
        Coin myNickel = new Nickel();

        myQuarter.value();
        myDime.value();
        myNickel.value();

    }
}