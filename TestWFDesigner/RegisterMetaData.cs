using System;
using System.Activities.Presentation.Metadata;
using System.Activities.Statements;
using System.ComponentModel;

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
        public class DesignerMetadata : IRegisterMetadata
        {

            public void Register()
            {
                AttributeTableBuilder builder = new AttributeTableBuilder();

                //Type stateType = typeof(State);
                //builder.AddCustomAttributes(stateType, new DesignerAttribute(typeof(StateDesigner)));
                //builder.AddCustomAttributes(stateType, stateType.GetProperty(StateDesigner.EntryPropertyName), BrowsableAttribute.No);
                //builder.AddCustomAttributes(stateType, stateType.GetProperty(StateDesigner.ExitPropertyName), BrowsableAttribute.No);
                //builder.AddCustomAttributes(stateType, stateType.GetProperty(StateContainerEditor.ChildStatesPropertyName), BrowsableAttribute.No);
                //builder.AddCustomAttributes(stateType, stateType.GetProperty(StateDesigner.TransitionsPropertyName), BrowsableAttribute.No);
                //builder.AddCustomAttributes(stateType, stateType.GetProperty(StateDesigner.IsFinalPropertyName), BrowsableAttribute.No);

                //Type transitionType = typeof(Transition);
                //builder.AddCustomAttributes(transitionType, new DesignerAttribute(typeof(TransitionDesigner)));
                //builder.AddCustomAttributes(transitionType, transitionType.GetProperty(TransitionDesigner.TriggerPropertyName), BrowsableAttribute.No);
                //builder.AddCustomAttributes(transitionType, transitionType.GetProperty(TransitionDesigner.ActionPropertyName), BrowsableAttribute.No);
                //builder.AddCustomAttributes(transitionType, transitionType.GetProperty(TransitionDesigner.ToPropertyName), BrowsableAttribute.No);

                MetadataStore.AddAttributeTable(builder.CreateTable());
            }
        }
    
}
