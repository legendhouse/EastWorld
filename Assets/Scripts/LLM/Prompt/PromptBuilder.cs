using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class PromptBuilder
{
    public static string Build(string templateName, Dictionary<string, object> args)
    {
        // 加载文本资源从 Resources/PromptTemplates 目录
        TextAsset templateFile = Resources.Load<TextAsset>($"PromptTemplates/{templateName}");

        if (templateFile == null)
        {
            throw new System.Exception($"Prompt template {templateName} not found in Resources/PromptTemplates.");
        }

        // 获取文本资源的内容
        string templateContent = templateFile.text;

        // 使用正则表达式替换具名占位符
        return Regex.Replace(templateContent, @"\{(.*?)\}", m =>
        {
            string key = m.Groups[1].Value;
            return args.ContainsKey(key) ? args[key].ToString() : m.Value;
        });
    }
}
