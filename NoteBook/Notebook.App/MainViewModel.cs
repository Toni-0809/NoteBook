using NoteBook.App.Core;
using NoteBook.Core;
using NoteBook.Core.Data;
using NoteBook.Core.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.App
{
    public class MainViewModel : ObservableObject
    {

        private string _input = string.Empty;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged("Input");
            }
        }

        private ObservableCollection<Note> _NoteList = new ObservableCollection<Note>();
        public ObservableCollection<Note> NoteList { get => _NoteList; set { _NoteList = value; OnPropertyChanged("NoteList"); }  }

        private NoteService NoteService;

        private Note _selectedNote;
        public Note SelectedNote { get => _selectedNote; 
            set { 
                _selectedNote = value;
                OnPropertyChanged("SelectedNote");
            } }

        public MainViewModel(NoteService service)
        {
            NoteService = service;
            NoteList = new ObservableCollection<Note>(NoteService.GetAll());
        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      NoteService.Create(
                          new Note(0, Input)
                          );
                      NoteList = new ObservableCollection<Note>(NoteService.GetAll());
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      NoteService.Delete(
                          SelectedNote.Id
                          );
                      NoteList = new ObservableCollection<Note>(NoteService.GetAll());
                  }));
            }
        }



    }
}
