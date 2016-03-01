<?xml version="1.0" encoding="UTF-8"?>
<drawing version="7">
    <attr value="xc9500xl" name="DeviceFamilyName">
        <trait delete="all:0" />
        <trait editname="all:0" />
        <trait edittrait="all:0" />
    </attr>
    <netlist>
        <signal name="q(3:0)" />
        <signal name="run" />
        <signal name="dir" />
        <signal name="clk" />
        <signal name="stop" />
        <signal name="XLXN_15" />
        <signal name="XLXN_16" />
        <signal name="XLXN_17" />
        <signal name="XLXN_18" />
        <signal name="XLXN_19" />
        <signal name="XLXN_20" />
        <signal name="XLXN_21" />
        <signal name="left" />
        <signal name="right" />
        <port polarity="BiDirectional" name="q(3:0)" />
        <port polarity="Input" name="clk" />
        <port polarity="Input" name="stop" />
        <port polarity="Input" name="left" />
        <port polarity="Input" name="right" />
        <blockdef name="gnd">
            <timestamp>2003-3-5T16:45:32</timestamp>
            <line x2="64" y1="-128" y2="-96" x1="64" />
            <line x2="64" y1="-64" y2="-80" x1="64" />
            <line x2="40" y1="-64" y2="-64" x1="88" />
            <line x2="60" y1="-32" y2="-32" x1="68" />
            <line x2="52" y1="-48" y2="-48" x1="76" />
            <line x2="64" y1="-64" y2="-96" x1="64" />
        </blockdef>
        <blockdef name="inv">
            <timestamp>2003-3-5T16:45:32</timestamp>
            <line x2="64" y1="-32" y2="-32" x1="0" />
            <line x2="160" y1="-32" y2="-32" x1="224" />
            <line x2="128" y1="-64" y2="-32" x1="64" />
            <line x2="64" y1="-32" y2="0" x1="128" />
            <line x2="64" y1="0" y2="-64" x1="64" />
            <circle r="16" cx="144" cy="-32" />
        </blockdef>
        <blockdef name="or2b2">
            <timestamp>2003-3-5T16:45:32</timestamp>
            <line x2="32" y1="-64" y2="-64" x1="0" />
            <circle r="12" cx="44" cy="-64" />
            <line x2="32" y1="-128" y2="-128" x1="0" />
            <circle r="12" cx="44" cy="-128" />
            <line x2="192" y1="-96" y2="-96" x1="256" />
            <arc ex="48" ey="-144" sx="48" sy="-48" r="56" cx="16" cy="-96" />
            <line x2="48" y1="-48" y2="-48" x1="112" />
            <arc ex="112" ey="-144" sx="192" sy="-96" r="88" cx="116" cy="-56" />
            <line x2="48" y1="-144" y2="-144" x1="112" />
            <arc ex="192" ey="-96" sx="112" sy="-48" r="88" cx="116" cy="-136" />
        </blockdef>
        <blockdef name="fjkc">
            <timestamp>2003-3-5T16:45:32</timestamp>
            <line x2="64" y1="-128" y2="-128" x1="0" />
            <line x2="64" y1="-32" y2="-32" x1="0" />
            <line x2="64" y1="-320" y2="-320" x1="0" />
            <line x2="320" y1="-256" y2="-256" x1="384" />
            <line x2="64" y1="-256" y2="-256" x1="0" />
            <line x2="64" y1="-32" y2="-32" x1="192" />
            <line x2="192" y1="-64" y2="-32" x1="192" />
            <line x2="64" y1="-128" y2="-144" x1="80" />
            <line x2="80" y1="-112" y2="-128" x1="64" />
            <rect width="256" x="64" y="-384" height="320" />
        </blockdef>
        <blockdef name="jcounter">
            <timestamp>2003-3-13T21:7:28</timestamp>
            <line x2="384" y1="80" y2="80" style="linewidth:W" x1="352" />
            <line x2="32" y1="112" y2="112" x1="0" />
            <line x2="32" y1="80" y2="80" x1="0" />
            <line x2="32" y1="48" y2="48" x1="0" />
            <rect style="linewidth:W" width="320" x="32" y="0" height="160" />
        </blockdef>
        <block symbolname="gnd" name="I14">
            <blockpin signalname="XLXN_16" name="G" />
        </block>
        <block symbolname="inv" name="I10">
            <blockpin signalname="left" name="I" />
            <blockpin signalname="XLXN_17" name="O" />
        </block>
        <block symbolname="inv" name="I11">
            <blockpin signalname="right" name="I" />
            <blockpin signalname="XLXN_18" name="O" />
        </block>
        <block symbolname="inv" name="I12">
            <blockpin signalname="stop" name="I" />
            <blockpin signalname="XLXN_19" name="O" />
        </block>
        <block symbolname="or2b2" name="I13">
            <blockpin signalname="right" name="I0" />
            <blockpin signalname="left" name="I1" />
            <blockpin signalname="XLXN_20" name="O" />
        </block>
        <block symbolname="fjkc" name="run_reg">
            <blockpin signalname="clk" name="C" />
            <blockpin signalname="XLXN_16" name="CLR" />
            <blockpin signalname="XLXN_18" name="J" />
            <blockpin signalname="XLXN_17" name="K" />
            <blockpin signalname="dir" name="Q" />
        </block>
        <block symbolname="fjkc" name="dir_reg1">
            <blockpin signalname="clk" name="C" />
            <blockpin signalname="XLXN_16" name="CLR" />
            <blockpin signalname="XLXN_20" name="J" />
            <blockpin signalname="XLXN_19" name="K" />
            <blockpin signalname="run" name="Q" />
        </block>
        <block symbolname="jcounter" name="U1">
            <blockpin signalname="run" name="CE" />
            <blockpin signalname="clk" name="CLK" />
            <blockpin signalname="dir" name="LEFT" />
            <blockpin signalname="q(3:0)" name="Q(3:0)" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="3520" height="2720">
        <instance x="1472" y="2048" name="I14" orien="R0" />
        <instance x="1216" y="1536" name="I10" orien="R0" />
        <instance x="1216" y="1472" name="I11" orien="R0" />
        <instance x="1216" y="1136" name="I12" orien="R0" />
        <instance x="1216" y="1040" name="I13" orien="R0" />
        <instance x="1584" y="1760" name="run_reg" orien="R0" />
        <instance x="1584" y="1264" name="dir_reg1" orien="R0" />
        <instance x="2128" y="960" name="U1" orien="R0">
        </instance>
        <branch name="q(3:0)">
            <wire x2="3152" y1="1040" y2="1040" x1="2512" />
        </branch>
        <iomarker fontsize="28" x="3152" y="1040" name="q(3:0)" orien="R0" />
        <branch name="run">
            <attrtext style="alignment:SOFT-BCENTER" attrname="Name" x="2016" y="1008" type="branch" />
            <wire x2="2016" y1="1008" y2="1008" x1="1968" />
            <wire x2="2128" y1="1008" y2="1008" x1="2016" />
        </branch>
        <branch name="dir">
            <attrtext style="alignment:SOFT-TVCENTER" attrname="Name" x="2016" y="1120" type="branch" />
            <wire x2="2016" y1="1504" y2="1504" x1="1968" />
            <wire x2="2016" y1="1040" y2="1120" x1="2016" />
            <wire x2="2016" y1="1120" y2="1504" x1="2016" />
            <wire x2="2128" y1="1040" y2="1040" x1="2016" />
        </branch>
        <iomarker fontsize="28" x="800" y="1840" name="clk" orien="R180" />
        <branch name="stop">
            <wire x2="896" y1="1104" y2="1104" x1="800" />
            <wire x2="992" y1="1104" y2="1104" x1="896" />
            <wire x2="1216" y1="1104" y2="1104" x1="992" />
        </branch>
        <iomarker fontsize="28" x="800" y="1104" name="stop" orien="R180" />
        <branch name="XLXN_16">
            <wire x2="1584" y1="1232" y2="1232" x1="1536" />
            <wire x2="1536" y1="1232" y2="1728" x1="1536" />
            <wire x2="1536" y1="1728" y2="1920" x1="1536" />
            <wire x2="1584" y1="1728" y2="1728" x1="1536" />
        </branch>
        <branch name="XLXN_17">
            <wire x2="1584" y1="1504" y2="1504" x1="1440" />
        </branch>
        <branch name="XLXN_18">
            <wire x2="1584" y1="1440" y2="1440" x1="1440" />
        </branch>
        <branch name="XLXN_19">
            <wire x2="1440" y1="1008" y2="1104" x1="1440" />
            <wire x2="1584" y1="1008" y2="1008" x1="1440" />
        </branch>
        <branch name="XLXN_20">
            <wire x2="1584" y1="944" y2="944" x1="1472" />
        </branch>
        <branch name="left">
            <wire x2="1168" y1="912" y2="912" x1="800" />
            <wire x2="1216" y1="912" y2="912" x1="1168" />
            <wire x2="1168" y1="912" y2="1504" x1="1168" />
            <wire x2="1216" y1="1504" y2="1504" x1="1168" />
        </branch>
        <iomarker fontsize="28" x="800" y="912" name="left" orien="R180" />
        <branch name="right">
            <wire x2="896" y1="976" y2="976" x1="800" />
            <wire x2="1200" y1="976" y2="976" x1="896" />
            <wire x2="1216" y1="976" y2="976" x1="1200" />
            <wire x2="1200" y1="976" y2="1440" x1="1200" />
            <wire x2="1216" y1="1440" y2="1440" x1="1200" />
        </branch>
        <iomarker fontsize="28" x="800" y="976" name="right" orien="R180" />
        <branch name="clk">
            <wire x2="896" y1="1840" y2="1840" x1="800" />
            <wire x2="1488" y1="1840" y2="1840" x1="896" />
            <wire x2="2080" y1="1840" y2="1840" x1="1488" />
            <wire x2="1488" y1="1136" y2="1632" x1="1488" />
            <wire x2="1488" y1="1632" y2="1840" x1="1488" />
            <wire x2="1584" y1="1632" y2="1632" x1="1488" />
            <wire x2="1584" y1="1136" y2="1136" x1="1488" />
            <wire x2="2080" y1="1072" y2="1840" x1="2080" />
            <wire x2="2128" y1="1072" y2="1072" x1="2080" />
        </branch>
    </sheet>
</drawing>