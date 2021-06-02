using System.ComponentModel;

namespace ApiManager.Core.Entities
{
    public class Parameter
    {
        public string? Id {get; set;}
        public string? Name {get; set;}
        public string? Description {get; set;}
        public string? Comment { get; set;}
        public ParameterType Type { get; set; }
        public ParameterCategory Category { get; set; }
        public string? ApiId {get; set;}
        public string? ParentId {get; set;}
    }

    public enum ParameterType
    {
        [Description("字符串")]
        String = 1,
        [Description("数字")]
        Number = 2,
        [Description("布尔类型")]
        Boolean = 3,
        [Description("数组")]
        Array = 4,
        [Description("对象类型")]
        Object = 5
    }

    public enum ParameterCategory
    {
        [Description("输入参数")]
        Input = 1,
        [Description("输出参数")]
        Output = 2,
        [Description("异常参数")]
        Exception = 3
    }
}
