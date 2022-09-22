namespace MauiApp1;

[QueryProperty(nameof(Student), "student")]
public partial class PageWithStudentsList : ContentPage
{
    Student student;
	public PageWithStudentsList()
	{	
		InitializeComponent();
        BindingContext = this;
        //Console.WriteLine("el estudiante es" + Student.Name);
    }
    public Student Student
    {
        get => student;
        set
        {
            student = value;
            OnPropertyChanged();
        }
    }
}