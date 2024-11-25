using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

var app = Application.Launch(@"C:\Temp\ispp21\MassCultureLibrary-master\MassCultureLibrary.Desktop\bin\Debug\net8.0-windows\MassCultureLibrary.Desktop.exe");
var automation = new UIA3Automation();

var window = app.GetMainWindow(automation);
window.FindFirstDescendant(ab => ab.ByText("Anime")).AsButton().Click();

var addButton = window.FindFirstDescendant(ab => ab.ByText("Добавить"));
addButton.Click();
Console.ReadLine();
window.FindFirstDescendant(mb => mb.ByAutomationId("2")).Click();

var title = window.FindFirstDescendant(t => t.ByAutomationId("TitleTextBox")).AsTextBox();
var genre = window.FindFirstDescendant(g => g.ByAutomationId("GenreTextBox")).AsTextBox();
title.Enter("Аниме");
genre.Enter("Экшен");
addButton.Click();

window.FindFirstDescendant(c => c.ByText("Наруто")).AsGridCell().RightClick();
Thread.Sleep(1000);
window.CaptureToFile("screenshot.png");
window.FindFirstDescendant(mi => mi.ByAutomationId("DeleteMenuItem")).Click();
window.FindFirstDescendant(c => c.ByText("Аниме")).AsGridCell().RightClick();
window.FindFirstDescendant(mi => mi.ByAutomationId("DeleteMenuItem")).Click();
Console.ReadLine();
window.FindFirstDescendant(mb => mb.ByAutomationId("2")).Click();
Console.ReadLine();
app.Close();