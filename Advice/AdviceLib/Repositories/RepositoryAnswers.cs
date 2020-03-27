using AdviceLib.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using AdviceLib.Models;
using DataAccess;
using System.Linq;

namespace AdviceLib.Repositories
{
    public class RepositoryAnswers : IRepositoryAnswers<Answers1>
    {
        AdviceDbContext ADC;

        public RepositoryAnswers()
        {
            ADC = new AdviceDbContext();
        }
        public RepositoryAnswers(AdviceDbContext AD)
        {
            ADC = AD ?? throw new ArgumentNullException(nameof(AD));
        }

        public void CreateAnswers(Answers1 Answers)
        {
            ADC.Answers.Add(Mappings.MapAnswers.Map(Answers));// this will generate insertMapper.Map(Answers)
            ADC.SaveChanges();// this will execute the above generate insert query
        }

        public void DeleteAnswers(int id)
        {
            var Cus = ADC.Answers.FirstOrDefault(Cx => Cx.ID == id);
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

        public IEnumerable<Answers1> ReadInAnswers()
        {
            var getCx = from cx in ADC.Answers
                        select Mappings.MapAnswers.Map(cx);
            return getCx;
        }

        public IEnumerable<Answers1> ReadInAnswers(int id)
        {
            var getCx = from cx in ADC.Answers.OrderByDescending(e=>e.ID == id)
                        select Mappings.MapAnswers.Map(cx);
            return getCx;
        }

        public IEnumerable<Answers1> ReadInAnswersBasedOnQuestion(int q_id)
        {
            var getCx = from cx in ADC.Answers.OrderByDescending(e => e.Question_ID == q_id)
                        select Mappings.MapAnswers.Map(cx);
            return getCx;
        }

        public void UpdateAnswers(Answers1 Answers)
        {
            if (ADC.Answers.Any(Cx => Cx.ID == Answers.ID))
            {
                var Cus = ADC.Answers.FirstOrDefault(Cx => Cx.ID == Answers.ID);
                Cus.Upvotes = Answers.Upvotes;
                Cus.Visited = Answers.Visited;
                ADC.Answers.Update(Cus);
                ADC.SaveChanges();
            }
        }
    }
}
