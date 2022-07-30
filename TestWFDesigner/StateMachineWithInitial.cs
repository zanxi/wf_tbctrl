using System.Activities;
using System.Activities.Presentation;
using System.Windows;

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
    
        


        public sealed class StateMachineWithInitialStateFactory : IActivityTemplateFactory
        {

            public Activity Create(DependencyObject target)
            {

                State state = new State()
                {
                    DisplayName = "Первый бизнес узел"
                };
                return new StateMachine()
                {
                    States = { state, new State() { IsFinal = true } },
                    InitialState = state

                };
            }
        }
    }
