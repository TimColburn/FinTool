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
            regExStringRepository.Create( "APRIL VEERA", "Wages");
            regExStringRepository.Create( "Cash eWithdrawal in Branch", "Misc");
            regExStringRepository.Create( "DEPOSIT FROM BANK BY MAIL", "Misc Income");
            regExStringRepository.Create( "RENTERWAY OWNERFUNDS", "Misc Income");
            regExStringRepository.Create( "Corint Drivers RECURRING", "Misc Mortgage");
            regExStringRepository.Create( "Mane Storage RECURRING", "Misc Mortgage");
            regExStringRepository.Create( "Monetary Grammers WEB PMTS", "Mortgage");
            regExStringRepository.Create( "RECURRING TRANSFER TO SCHLOGGS W SAVINGS", "Savings");
            regExStringRepository.Create( "BILL PAY APS", "Utilities");
            regExStringRepository.Create( "BILL PAY Tee Mob", "Phone");
            regExStringRepository.Create( "TRANSFER FROM TUNE L JAM", "Misc Income");
            regExStringRepository.Create( "BILL PAY BoA for Let's Us RECURRING", "Misc");
            regExStringRepository.Create( "Diamonte", "Netor");
            regExStringRepository.Create( "BILL PAY PNC Bank RECURRING", "Mortgage");
            regExStringRepository.Create( "BILL PAY Scootda Spg Cond RECURRING ", "Misc Mortgage");
            regExStringRepository.Create( "MONTHLY SERVICE FEE", "Misc");
            regExStringRepository.Create( "INTEREST PAYMENT", "Misc");
            regExStringRepository.Create( "BILL PAY CITY OF PHOENIX", "House");
            regExStringRepository.Create( "TO VISA SIGNATURE CARD", "VISA Card");
            regExStringRepository.Create( "TRANSFER TO DENNIS CONE", "To Dennis");
            regExStringRepository.Create( "eDeposit in Branch", "Misc Income");
            regExStringRepository.Create( "SAFEWAY STORE ", "Food");
            regExStringRepository.Create( "BILL PAY Scootda Spg Cond ", "Rental");
            regExStringRepository.Create( "BILL PAY KOHLS ", "Clothes");
            regExStringRepository.Create( "CHECK #", "Misc");
            regExStringRepository.Create( "BILL PAY PNC Bank ", "Mortgage");
            regExStringRepository.Create( "BILL PAY HOME DEPOT", "House");

            context.SaveChanges();
            base.Seed(context);
        }

    }
}