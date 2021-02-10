# CheckIn 极简签到系统

任何有一定规模的组织和机构在日常运行过程中,各种原因需要开会培训报名等事情都需要有签到和报名的要求。
这种需求发生的概率不高，但是每次签到之后的统计都是挺麻烦的事情。
利用先有的云服务和软件技术，完全可以将这个需求独立出来，做成一个手机APP。
而极简签到系统的设计原则是用最简单的设计，实现95%签到场景中签名和汇总的功能。

# 用户角色和使用流程
本系统设计中用户分为两个角色，签到事务管理者和签到人。
## 签到事务管理者（以下简称 管理员）：
管理员可以发起签到任务，发起一次或者多次都可以；
发起签到任务之后，将签到任务的二维码截图通过即时通信软件邮件或者其他的通讯手段发送给需要签到的人（签到人）；
甚至是将二维码打印下来在会议现场让与会者扫码签到也可以。
## 签到人：这是会议课程的参与者
他们需要参与会议并且签到，这种场景下，以微信为例，接收到签到任务截图，扫描二维码即可填写签到内容。
