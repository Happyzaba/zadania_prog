using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp
{
    internal class ViewModel : BindableObject
    {
        private string[] questionContent = ["pierwsze pytanie", "2 pytanie", "3 pytanie", "4 pytanie"];
        private string[,] answersContent = { { "1", "2", "3", "4" }, { "21", "22", "23", "24" }, { "31", "32", "33", "34" }, { "41", "42", "43", "44" } };
        private string[] correctAnsers = ["2", "21", "32", "44"];

        private bool isCorrectOne;
        private static int score = 0; 
        public bool IsCorrectOne
        {
            get { return isCorrectOne; }
            set { isCorrectOne = value; }
        }


        private string answerOne = "";
        public string AnswerOne
        {
            get { return answerOne; }
            set { answerOne = answersContent[questionNumber, 0]; OnPropertyChanged(); }
        }

        private string answerTwo = "";
        public string AnswerTwo
        {
            get { return answerTwo; }
            set { answerTwo = answersContent[questionNumber,1]; OnPropertyChanged(); }
        }

        private string answerThree="";
        public string AnswerThree
        {
            get { return answerThree; }
            set { answerThree = answersContent[questionNumber, 2]; OnPropertyChanged(); }
        }

        private string answerFour = "";
        public string AnswerFour
        {
            get { return answerFour; }
            set { answerFour = answersContent[questionNumber, 3]; OnPropertyChanged(); }
        }

        private int questionNumber = 0;
        public int QuestionNumber
        {
            get { return questionNumber; }
            set { questionNumber = value; }
        }

        private string questionText = "1";
        public string QuestionText 
        {
            get { return questionText; }
            set { questionText = questionContent[QuestionNumber]; OnPropertyChanged(); }
        }

        private Command previousQuestion = null;
        public Command PreviousQuestion
        {
            get { return previousQuestion; }
            set { previousQuestion = value; }
        }

        private Command nextQuestion = null;
        public Command NextQuestion
        {
            get { return nextQuestion; }
            set { nextQuestion = value; }
        }

        public ViewModel() {
            QuestionText = "";
            AnswerOne = "";
            AnswerTwo = "";
            AnswerThree = "";
            AnswerFour = "";
            PreviousQuestion = new Command(PreviousQuestionM);
            NextQuestion = new Command(NextQuestionM);
        }

        private void PreviousQuestionM()
        {
            CheckCorrectAnswer();
            QuestionNumber--;
            if (QuestionNumber < 0) {
                QuestionNumber = questionContent.Length-1;
            }
            QuestionText = "";
            AnswerOne = "";
            AnswerTwo = "";
            AnswerThree = "";
            AnswerFour = "";
        }

        private void NextQuestionM()
        {
            CheckCorrectAnswer();
            QuestionNumber++;
            if (QuestionNumber > questionContent.Length-1)
            {
                QuestionNumber = 0;
            }
            QuestionText = "";
            AnswerOne = "";
            AnswerTwo = "";
            AnswerThree = "";
            AnswerFour = "";
        }
        private void CheckCorrectAnswer()
        {
            if (correctAnsers[questionNumber] == checkAnswers()) {
                score++;
            };
            return;
        }

        private string checkAnswers()
        {
            if (isCorrectOne == true)
            {
                return answersContent[questionNumber, 0];
            }
            else {
                return "";
            }
        }
    }
}
