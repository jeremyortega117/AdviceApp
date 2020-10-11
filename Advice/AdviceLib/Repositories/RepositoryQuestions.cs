//using AdviceLib.IRepository;
//using AdviceLib.Models;
//using DataAccess;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace AdviceLib.Repositories
//{
//    public class RepositoryQuestions : IRepositoryQuestions<Questions1>
//    {
//        AdviceDbContext ADC;

//        public RepositoryQuestions()
//        {
//            ADC = new AdviceDbContext();
//        }
//        public RepositoryQuestions(AdviceDbContext AD)
//        {
//            ADC = AD ?? throw new ArgumentNullException(nameof(AD));
//        }

//        public void CreateQuestion(Questions1 Question)
//        {
//            ADC.Questions.Add(Mappings.MapQuestions.Map(Question));// this will generate insertMapper.Map(Questions)
//            ADC.SaveChanges();// this will execute the above generate insert query
//        }

//        public void DeleteQuestion(int id)
//        {
//            var Cus = ADC.Questions.FirstOrDefault(Cx => Cx.ID == id);
//            if (Cus.ID == id)
//            {
//                ADC.Remove(Cus);
//                ADC.SaveChanges();
//            }
//            else
//            {
//                Console.WriteLine($"Cx with id {id} doesn't exist");
//                return;
//            }
//        }

//        public IEnumerable<Questions1> ReadInQuestion()
//        {
//            var getCx = from cx in ADC.Questions
//                        select Mappings.MapQuestions.Map(cx);
//            return getCx;
//        }

//        public IEnumerable<Questions1> ReadInQuestion(int id)
//        {
//            var getCx = from cx in ADC.Questions.OrderByDescending(e => e.ID == id)
//                        select Mappings.MapQuestions.Map(cx);
//            return getCx;
//        }

//        public void UpdateQuestion(Questions1 Question)
//        {
//            if (ADC.Questions.Any(Cx => Cx.ID == Question.ID))
//            {
//                var Cus = ADC.Questions.FirstOrDefault(Cx => Cx.ID == Question.ID);
//                Cus.Upvotes = Question.Upvotes;
//                Cus.Visited = Question.Visited;
//                ADC.Questions.Update(Cus);
//                ADC.SaveChanges();
//            }
//        }
//    }
//}
