# Instead-PowerShell
 .NET 通过调用API接口模拟实现PowerShell

## 0x01

Invoke-Expression 是 PowerShell 中的一个强大命令，用于执行一个字符串内容中包含的命令、表达式或脚本。

## 0x02

PowerShell.AddScript 是 .NET API 提供的接口，用于将 PowerShell 脚本添加到一个 PowerShell 对象的脚本管道中,可以动态生成 PowerShell 脚本内容并在程序执行时运行。

在实际场景中，可以通过 PowerShell.AddScript 在.NET中使用 PowerShell 脚本引擎来执行命令，例如 Invoke-Expression，并通过 Invoke() 方法获取whoami执行的结果。

编程难点：在于 System.Management.Automation，是需要dll文件（System.Management.Automation.dll）引用的。

```c#
using System;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace Instead_PowerShell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(args[0]);
            try
            {
                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddScript("Invoke-Expression " + args[0]);

                    Collection<PSObject> results = powerShell.Invoke();

                    foreach (PSObject result in results)
                    {
                        Console.WriteLine(result.ToString());
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invoke needs param");
                Console.ResetColor();
            }
        }
    }
}

```

![image-20250106175612593](assets/image-20250106175612593.png)
