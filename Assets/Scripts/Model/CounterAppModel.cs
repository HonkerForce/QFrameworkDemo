using QFrameworkTest;
namespace CounterApp
{
    public class CounterAppModel : Model<int>
    {
        public override int Value
        {
            get => m_value;
            set
            {
                m_value = value;
                if (OnValueChanged != null)
                {
                    OnValueChanged(m_value);
                }
            }
        }
    }
}