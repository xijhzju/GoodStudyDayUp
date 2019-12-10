
学习刘铁猛（Timothy LIU)的C#视频有关依赖注入、反射的代码
====================================
1: PROJECT DependencyInjectionLearn in folder Reflection:
演示反射的基本用法；
演示依赖注入的基本使用。

2: PROJECT BabyStroller in folder Reflection。
以一个需要第三方动物类参与的婴儿车程序为例演示反射的具体应用。
此工程为婴儿车的主体程序，第三方的动物类需要放在程序内的Animals文件夹内

3：PROJECT Animals.Lib
演示BabyStroller所需的动物类的第三方开发。
开发得到的库应该复制到婴儿车程序的Animals文件夹内。


4：PROJECT BabyStroller.SDK
官方发布的SDK。
其实就2个东西
一个是第三方开发者开发Animal时需要满足IAnimals接口（防止开发时的误操作，比如必须有的Voice方法写错之类的）；
一个是UnfinishedAnimals特性，供开发方标注未完成的动物类时使用。

============================



