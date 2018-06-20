using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace ACMEControl.Command
{
    public class EventToCommand : TriggerAction<DependencyObject>
    {
        /// <summary>
        /// 命令
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(EventToCommand), new PropertyMetadata(null));

        /// <summary>
        /// 命令传入的参数
        /// </summary>
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventToCommand), new PropertyMetadata(null));

        /// <summary>
        /// 是否传入参数
        /// </summary>
        public bool PassEventArgsToCommand { get; set; }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="parameter"></param>
        protected override void Invoke(object parameter)
        {
            if (this.Command == null)
            {
                return;
            }

            //参数转换为数组类型再传入委托
            List<object> input = new List<object>();

            if (this.CommandParameter != null)
            {
                if (this.CommandParameter is Array)
                {
                    input.AddRange(this.CommandParameter as object[]);
                }
                else
                {
                    input.Add(this.CommandParameter);
                }
            }

            if (PassEventArgsToCommand == true)
            {
                input.Add(parameter);
            }

            object[] obj = input.ToArray();

            //如果类型转换不一致则抛出异常
            try
            {
                object param = obj.Length == 1 ? obj[0] : obj;
                if (this.Command.CanExecute(param))
                    this.Command.Execute(param);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
