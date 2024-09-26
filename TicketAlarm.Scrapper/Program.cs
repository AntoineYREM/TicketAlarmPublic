using TicketAlarm.Scrapper.Library;
using static System.Net.WebRequestMethods;

IScrapper scrapper = new Scrapper();


string[] listShow = {
"https://www.fnacspectacles.com/event/clara-luciani-tournee-accor-arena-18524846/                                                       "  ,
"https://www.fnacspectacles.com/event/sabrina-carpenter-short-n-sweet-tour-accor-arena-18939898/#tab=                                   "  ,
"https://www.fnacspectacles.com/event/sabrina-carpenter-short-n-sweet-tour-accor-arena-18961477/                                        "  ,
"https://www.fnacspectacles.com/event/julien-dore-tournee-accor-arena-17888800/#tab=                                                    "  ,
"https://www.fnacspectacles.com/event/julien-dore-tournee-accor-arena-17888801/                                                         "  ,
"https://www.fnacspectacles.com/event/la-fouine-tournee-accor-arena-18621889/                                                           "  ,
"https://www.fnacspectacles.com/event/twenty-one-pilots-the-clancy-world-tour-accor-arena-18495628/#tab=                                "  ,
"https://www.fnacspectacles.com/event/indochine-arena-tour-accor-arena-19149667/                                                        "  ,
"https://www.fnacspectacles.com/event/indochine-arena-tour-accor-arena-19149668/                                                        "  ,
"https://www.fnacspectacles.com/event/indochine-arena-tour-accor-arena-19105462/                                                        "  ,
"https://www.fnacspectacles.com/event/indochine-arena-tour-accor-arena-19105463/                                                        "  ,
"https://www.fnacspectacles.com/event/katy-perry-the-lifetimes-tour-accor-arena-19562189/                                               "  ,
"https://www.fnacspectacles.com/event/dua-lipa-radical-optimism-tour-paris-la-defense-arena-19131040/                                   "  ,
"https://www.fnacspectacles.com/event/dua-lipa-radical-optimism-tour-paris-la-defense-arena-19167020/                                   "  ,
"https://www.fnacspectacles.com/event/iron-maiden-run-for-your-lives-world-tour-paris-la-defense-arena-19157750/#tab=                   "

};


foreach  (var url in listShow)
{
    //Console.WriteLine("URL Fnac du show : ");
    //var urlEvent = Console.ReadLine() ?? "";
    await scrapper.AddShow(url);
}