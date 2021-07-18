# TensorDebuggerVisualizers

#### 介绍
方便调试时即时查看张量内容的《张量查看器》。

大家有兴趣的话可以试用一下了： [预试用版]

#### 软件架构
软件架构说明


#### 安装教程

将调试器端 DLL（以及它所依赖的任意 DLL）复制到以下位置之一：

* \<VisualStudio 安装路径>\Common7\Packages\Debugger\Visualizers

* 我的文档 \\\<VisualStudio 版本>\Visualizers

将调试对象端 DLL 复制到下列位置之一：

* \<VisualStudio 安装路径>\Common7\Packages\Debugger\Visualizers\ **Framework**

* 我的文档 \\\<VisualStudio 版本>\Visualizers\ **Framework**

其中 **Framework**：

* 对于运行 .NET Framework 运行时的调试对象，为 ```net2.0```。
* 对于使用支持 netstandard 2.0（.NET Framework v4.6.1+ 或 .NET Core 2.0+）的运行时的调试对象，为 ```netstandard2.0```。
* 对于运行 .NET Core 运行时的调试对象，为 ```netcoreapp```。 （支持 .NET Core 2.0+）

资料来源：[如何：安装可视化工具](https://docs.microsoft.com/zh-cn/visualstudio/debugger/how-to-install-a-visualizer)

举例一个具体的安装实例：

    下载 [预试用版] 。
    将压缩包解压（某些情况下解压缩前注意右键属性解安全限定），
    将目录中的文件复制到
    我的文档\Visual Studio 2019\Visualizers\
     下即可。

注意，可能最新版的 [SharpCV] 才可以使用，因为需要用到最近添加的图像编码函数 ImDecode/ImEncode 才行。


#### 使用说明

具体使用方法如下：
在正确安装以后，在 VisualStudio 当在调试中断状态时，当鼠标放到变量上时，会出现IDE的类似放大镜的变量查看器图标。
点击下拉箭头就能看到：

![TensorVisualizer]

选择【Mat Visualizer】就会出现：

![TensorViewer]

查看到 SharpCV.Mat 对象的具体内容了。

#### 参与贡献

此文档的外文版本实在没精力搞了，哪位同学有时间帮忙搞下吧！

1.  Fork 本仓库
2.  新建 Feat_xxx 分支
3.  提交代码
4.  新建 Pull Request


#### 特技

1.  使用 Readme\_XXX.md 来支持不同的语言，例如 Readme\_en.md, Readme\_zh.md
2.  Gitee 官方博客 [blog.gitee.com](https://blog.gitee.com)
3.  你可以 [https://gitee.com/explore](https://gitee.com/explore) 这个地址来了解 Gitee 上的优秀开源项目
4.  [GVP](https://gitee.com/gvp) 全称是 Gitee 最有价值开源项目，是综合评定出的优秀开源项目
5.  Gitee 官方提供的使用手册 [https://gitee.com/help](https://gitee.com/help)
6.  Gitee 封面人物是一档用来展示 Gitee 会员风采的栏目 [https://gitee.com/gitee-stars/](https://gitee.com/gitee-stars/)

[预试用版]:../../releases/v1_mat_0.1
[SharpCV]:../../../..//SciSharp/SharpCV
[TensorVisualizer]:docs/zhCN/TensorVisualizer.png
[TensorViewer]:docs/zhCN/MatViewer.png
