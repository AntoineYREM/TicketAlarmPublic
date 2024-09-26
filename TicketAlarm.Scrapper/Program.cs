// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using System.Runtime.CompilerServices;
using TicketAlarm.Scrapper;

Scrapper scrapper = new Scrapper();

while (true)
{
    var urlEvent = Console.ReadLine();
    scrapper.ScrapEventAsync(urlEvent);
}

