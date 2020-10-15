using AdviceLib.IRepository;
using AdviceLib.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdviceLib.Repositories
{
    public class RepositoryMessages : IRepositoryMessages<Messages1>
    {
        public AdviceDbContext ADC;

        public RepositoryMessages()
        {
            ADC = new AdviceDbContext();
        }
        public RepositoryMessages(AdviceDbContext AD)
        {
            ADC = AD ?? throw new ArgumentNullException(nameof(AD));
        }

        /// <summary>
        /// Create message
        /// </summary>
        /// <param name="Messages"></param>
        public void CreateMessage(Messages1 Messages)
        {
            //          ADC.Messages.Add(Mappings.MapMessages.Map(Messages));
            ADC.SaveChanges();
        }

        /// <summary>
        /// Delete Message
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMessage(int id)
        {
                        var Cus = ADC.Messages.FirstOrDefault(Cx => Cx.ID == id);
            if (Cus.ID == id)
            {
                ADC.Remove(Cus);
                ADC.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Cx with id {id} doesn't exist");
                return;
            }
        }

        /// <summary>
        /// return all Messages from repository call.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Messages1> ReadInMessages()
        {
            var getAx = from ax in ADC.Messages
                        select Mappings.MapMessages.Map(ax);

            return getAx;
        }

        /// <summary>
        /// return single Message from repostory with matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Messages1 ReadInMessage(int id)
        {
            var a = ADC.Messages.FirstOrDefault(a => a.ID == id);
            if (a != null)
            {
                return Mappings.MapMessages.Map(a);
            }
            return null;
        }

        /// <summary>
        /// Update Message.
        /// </summary>
        /// <param name="Messages"></param>
        public void UpdateMessage(Messages1 Messages)
        {
            if (ADC.Messages.Any(Cx => Cx.ID == Messages.ID))
            {
                var Cus = ADC.Messages.FirstOrDefault((Cx => Cx.ID == Messages.ID));
                ADC.Messages.Update(Cus);
                ADC.SaveChanges();
            }
        }
    }
}
