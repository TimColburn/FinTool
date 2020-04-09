using FinTool.Data.Services;
using System.Data.Entity;

namespace FinTool.Data.Data
{
    public class FinToolDbInitializer : DropCreateDatabaseAlways<FinToolDbContext>
    {
        protected override void Seed(FinToolDbContext context)
        {
            var regExStringRepository = new RegExStringRepository(context);

            regExStringRepository.Create( "", "UNDEFINED");
            regExStringRepository.Create( "STATE FARM", "Auto");
            regExStringRepository.Create( "ATM WITHDRAWAL", "Misc");
            regExStringRepository.Create( "COX COMMUNICATIONS", "Enterainment");
            regExStringRepository.Create( "BILL PAY Merylin Che BoA", "Misc");
            regExStringRepository.Create( "APRIVA", "Wages");
            regExStringRepository.Create( "Cash eWithdrawal in Branch", "Misc");
            regExStringRepository.Create( "DEPOSIT FROM BANK BY MAIL", "Misc Income");
            regExStringRepository.Create( "RENTERS WAREHOUS", "Misc Income");
            regExStringRepository.Create( "Corrine Dr RECURRING", "Misc Mortgage");
            regExStringRepository.Create( "Main St RECURRING", "Misc Mortgage");
            regExStringRepository.Create( "MoneyGram WEB PMTS", "Misc");
            regExStringRepository.Create( "RECURRING TRANSFER TO COLBURN T SAVINGS", "Savings");
            regExStringRepository.Create( "BILL PAY APS", "Utilities");
            regExStringRepository.Create( "BILL PAY T Mobile", "Phone");
            regExStringRepository.Create( "TRANSFER FROM TUNELL", "Misc Income");
            regExStringRepository.Create( "BILL PAY BoA for Lexus", "Auto");
            regExStringRepository.Create( "BILL PAY Scottsdale Springs", "Misc Mortgage");
            regExStringRepository.Create( "MONTHLY SERVICE FEE", "Misc");
            regExStringRepository.Create( "INTEREST PAYMENT", "Misc");
            regExStringRepository.Create( "BILL PAY CITY OF PHOENIX", "House");
            regExStringRepository.Create( "TO VISA SIGNATURE CARD", "VISA Card");
            regExStringRepository.Create( "TRANSFER TO COLBURN GO", "To Dennis");
            regExStringRepository.Create( "eDeposit in Branch", "Misc Income");
            regExStringRepository.Create( "BILL PAY KOHLS ", "Clothes");
            regExStringRepository.Create( "CHECK #", "Misc");
            regExStringRepository.Create( "BILL PAY PNC Bank ", "Mortgage");
            regExStringRepository.Create( "BILL PAY HOME DEPOT", "House");

            context.SaveChanges();
            base.Seed(context);
        }

    }
}