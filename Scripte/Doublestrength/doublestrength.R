#old
#NMS = c(7,22,42,64,80)

#new
NMS = c(7,21,32,52,78)



DSN = NMS/2




plot(NA,xlim = c(min(DSN),max(NMS)), ylim=c(0,0))


points(NMS,rep(0, length(NMS)),col = "darkgreen", pch=17, cex=1.2)

points(DSN,rep(0.1, length(DSN)),col = "blue", pch=19, cex=1.2)



abline(v=45,lty =3)





