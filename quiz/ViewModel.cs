using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp
{
    internal class ViewModel : BindableObject
    {
        private List<Question> questions = new List<Question>();
        private class Question
        {
            private int id = 0;
            private string content = "";
            private string answerOne = "";
            private string answerTwo = "";
            private string answerThree = "";
            private string answerFour = "";
            private string correctAnswer = "";
            private string answerLocked = "";
            public Question(int id, string content,string answerOne, string answerTwo, string answerThree, string answerFour, string correctAnswer)
            {
                this.id = id;
                this.content = content;
                this.answerOne = answerOne;
                this.answerTwo = answerTwo;
                this.answerThree = answerThree;
                this.answerFour = answerFour;
                this.correctAnswer = correctAnswer;
             }
            public void SetAnswerLocked(string answerLocked) { 
                this.answerLocked = answerLocked;
            } 
            public  string GetAnswerLocked() {
                return this.answerLocked;
            }
            public string GetCorrectAnswer() { 
                return correctAnswer;
            }
            public string GetAnswerOne()
            {
                return answerOne;
            }
            public string GetAnswerTwo()
            {
                return answerTwo;
            }
            public string GetAnswerThree()
            {
                return answerThree;
            }
            public string GetAnswerFour()
            {
                return answerFour;
            }
            public string GetContent() { 
                return content;
            }
            public int GetId() {
                return id;
            }
        }
        private static int score = 0;

        private bool isCorrectOne;
        public bool IsCorrectOne
        {
            get { return isCorrectOne; }
            set { isCorrectOne = value; OnPropertyChanged(); }
        }

        private bool isCorrectTwo;
        public bool IsCorrectTwo
        {
            get { return isCorrectTwo; }
            set { isCorrectTwo = value; OnPropertyChanged(); }
        }

        private bool isCorrectThree;
        public bool IsCorrectThree
        {
            get { return isCorrectThree; }
            set { isCorrectThree = value; OnPropertyChanged(); }
        }

        private bool isCorrectFour;
        public bool IsCorrectFour
        {
            get { return isCorrectFour; }
            set { isCorrectFour = value; OnPropertyChanged(); }
        }

        private string showFinalScore = "";
        public string ShowFinalScore
        {
            get { return showFinalScore; }
            set { showFinalScore = "Wynik: "+score.ToString()+"/"+questions.Count.ToString(); OnPropertyChanged(); }
        }

        private string answerOne = "";
        public string AnswerOne
        {
            get { return answerOne; }
            set { answerOne = questions.Find(q => q.GetId() == questionNumber).GetAnswerOne(); OnPropertyChanged(); }
        }

        private string answerTwo = "";
        public string AnswerTwo
        {
            get { return answerTwo; }
            set { answerTwo = questions.Find(q => q.GetId() == questionNumber).GetAnswerTwo(); OnPropertyChanged(); }
        }

        private string answerThree="";
        public string AnswerThree
        {
            get { return answerThree; }
            set { answerThree = questions.Find(q => q.GetId() == questionNumber).GetAnswerThree(); OnPropertyChanged(); }
        }

        private string answerFour = "";
        public string AnswerFour
        {
            get { return answerFour; }
            set { answerFour = questions.Find(q => q.GetId() == questionNumber).GetAnswerFour(); OnPropertyChanged(); }
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
            set { questionText = questions.Find(q => q.GetId() == questionNumber).GetContent(); OnPropertyChanged(); }
        }

        private Command reset;
        public Command Reset
        {
            get { return reset; }
            set { reset = value; }
        }


        private Command getFinalScore;
        public Command GetFinalScore
        {
            get { return getFinalScore; }
            set { getFinalScore = value; }
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
            GenerateQuestions();
            UpdateLayout();
            PreviousQuestion = new Command(PreviousQuestionM);
            NextQuestion = new Command(NextQuestionM);
            GetFinalScore = new Command(FinalSocre);
            Reset = new Command(ResetQuiz);
        }

        private void ResetQuiz(object obj)
        {
            questionNumber = 0;
            foreach (Question question in questions) {
                question.SetAnswerLocked("");
            }
            score = 0;
            UpdateLayout();
            UnCheckAnswer();
        }

        private void FinalSocre(object obj)
        {
            foreach (Question q in questions) {
                if (q.GetAnswerLocked() == q.GetCorrectAnswer()) {
                    score = score + 1;
                }
            }
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            QuestionText = "";
            AnswerOne = "";
            AnswerTwo = "";
            AnswerThree = "";
            AnswerFour = "";
            ShowFinalScore = "";
        }

        private void GenerateQuestions()
        {
            Question questionOne = new Question(questions.Count,"Kiedy byla bitwa pod Grundwaldem", "pazdziernik 1410", "lipiec 1410", "wrzesien 1410", "listopad 1410", "lipiec 1410");
            questions.Add(questionOne);
            Question questionTwo = new Question(questions.Count, "Ile wynosi f`(x) od f(x) = 1/5 x^5 + 1/4 x^4 + 2/3 x^3 + 4. Podaj x pochodnej", "0,-2,1", "3,5", "-2,1,3", "-5,-2,0", "0,-2,1");
            questions.Add(questionTwo);
            Question questionThree = new Question(questions.Count, "Co to za znak: Σ", "Omega", "Alfa", "Sigma", "Beta", "Sigma");
            questions.Add(questionThree);
            Question questionFour = new Question(questions.Count, "Ile wynosi masa slonca", "Co najmniej jedno slonce", "Z milion ziem ", "100 ksiezycow", "1000 Jowiszy", "Co najmniej jedno slonce");
            questions.Add(questionFour);
        }

        private void PreviousQuestionM()
        {
            LockAnswer();
            QuestionNumber--;
            if (QuestionNumber < 0) {
                QuestionNumber = questions.Count-1;
            }
            UpdateLayout();
            UnCheckAnswer();
        }

        private void UnCheckAnswer()
        {
            IsCorrectOne = false;
            IsCorrectTwo = false;
            IsCorrectThree = false;
            IsCorrectFour = false;
        }

        private void LockAnswer()
        {
            foreach (Question q in questions) {
                if (q.GetId() == questionNumber) {
                    if (isCorrectOne == true)
                    {
                        q.SetAnswerLocked(q.GetAnswerOne());
                    }
                    else if (isCorrectTwo == true) {
                        q.SetAnswerLocked(q.GetAnswerTwo());
                    }
                    else if (isCorrectThree == true)
                    {
                        q.SetAnswerLocked(q.GetAnswerThree());
                    }
                    else if (isCorrectFour == true)
                    {
                        q.SetAnswerLocked(q.GetAnswerFour());
                    }
                }
            }
        }

        private void NextQuestionM()
        {
            LockAnswer();
            QuestionNumber++;
            if (QuestionNumber >= questions.Count)
            {
                QuestionNumber = 0;
            }
            UpdateLayout();
            UnCheckAnswer();
        }

    }
}
