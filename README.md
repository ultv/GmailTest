# Тестовое задание на вакансию разработчик в тестировании.

## Технологии
* [C#](https://docs.microsoft.com/ru-ru/dotnet/csharp/)
* [NUnit](http://nunit.org/)
* [Jenkins](https://jenkins.io/)
* [Selenium, SeleniumGrid](https://www.seleniumhq.org/)
* [Allure](http://allure.qatools.ru/)

## Инструкция

* Для стабильной работы браузера Firefox - требуется geckodriver.exe весии не ниже [v0.22.0](https://github.com/mozilla/geckodriver/releases)

* Необходимо настроить среду разработки и расположить файл config.json в директории bin/Debug/
```
{
    "Login":"*****",
    "Pass":"*****",
    "BaseUrl":"http://gmail.com",
    "Node":[
                {
                    "Uri":"http://192.168.0.1:16602/wd/hub",
                    "Capabilities":"chrome"
                },
                {
                    "Uri":"http://192.168.0.1:5556/wd/hub",
                    "Capabilities":"firefox"
                }                                                
            ],
    "SearchKey":"in:inbox ",
    "SearchText":"Имя Фамилия",    
    "Subject":"Тестовое задание. Фамилия",
    "Message":"Количество присланных писем = "
}
```
