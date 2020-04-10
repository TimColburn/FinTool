using FinTool.Data.Services;
using System.Data.Entity;

namespace FinTool.Data.Data
{
    public class FinToolDbInitializer : DropCreateDatabaseAlways<FinToolDbContext>
    {
        protected override void Seed(FinToolDbContext context)
        {
            var regExStringRepository = new RegExStringRepository(context);

            var regExStrings = regExStringRepository.GetAll();
            if (regExStrings != null && regExStrings.Count > 0)
                return;

            regExStringRepository.Create( "", "UNDEFINED");
            regExStringRepository.Create( "STATE FARM", "Auto");
            regExStringRepository.Create( "ATM WITHDRAWAL", "Misc");
            regExStringRepository.Create( "COX COMMUNICATIONS", "Enterainment");
            regExStringRepository.Create( "MERR", "Misc");
            regExStringRepository.Create( "APRI", "Wages");
            regExStringRepository.Create( "Cash eWithdrawal in Branch", "Misc");
            regExStringRepository.Create( "DEPOSIT FROM BANK BY MAIL", "Misc Income");
            regExStringRepository.Create( "RENTE", "Misc Income");
            regExStringRepository.Create( "Corrine Dr RECURRING", "Misc Mortgage");
            regExStringRepository.Create( "Main St RECURRING", "Misc Mortgage");
            regExStringRepository.Create( "Mone", "Misc");
            regExStringRepository.Create( "RECURRING TRANSFER TO COL T SAVINGS", "Savings");
            regExStringRepository.Create( "BILL PAY APS", "Utilities");
            regExStringRepository.Create( "BILL PAY T Mobile", "Phone");
            regExStringRepository.Create( "TRANSFER FROM TUNE", "Misc Income");
            regExStringRepository.Create( "BILL PAY BoA for Lex", "Auto");
            regExStringRepository.Create( "BILL PAY Scottsdale Springs", "Misc Mortgage");
            regExStringRepository.Create( "MONTHLY SERVICE FEE", "Misc");
            regExStringRepository.Create( "INTEREST PAYMENT", "Misc");
            regExStringRepository.Create( "BILL PAY CITY OF PHOENIX", "House");
            regExStringRepository.Create( "TO VISA SIGNATURE CARD", "VISA Card");
            regExStringRepository.Create( "TRANSFER TO COL GO", "To Dennis");
            regExStringRepository.Create( "eDeposit in Branch", "Misc Income");
            regExStringRepository.Create( "BILL PAY KOHLS ", "Clothes");
            regExStringRepository.Create( "CHECK #", "Misc");
            regExStringRepository.Create( "BILL PAY PNC Bank ", "Mortgage");
            regExStringRepository.Create( "OVERDRAFT", "Misc");
            regExStringRepository.Create( "WF Cre AUTO PAY", "Credit Card");

            context.SaveChanges();
            base.Seed(context);
        }

    }
}