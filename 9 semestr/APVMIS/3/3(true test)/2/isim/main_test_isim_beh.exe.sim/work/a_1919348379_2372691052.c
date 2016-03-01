/**********************************************************************/
/*   ____  ____                                                       */
/*  /   /\/   /                                                       */
/* /___/  \  /                                                        */
/* \   \   \/                                                       */
/*  \   \        Copyright (c) 2003-2009 Xilinx, Inc.                */
/*  /   /          All Right Reserved.                                 */
/* /---/   /\                                                         */
/* \   \  /  \                                                      */
/*  \___\/\___\                                                    */
/***********************************************************************/

/* This file is designed for use with ISim build 0x7708f090 */

#define XSI_HIDE_SYMBOL_SPEC true
#include "xsi.h"
#include <memory.h>
#ifdef __GNUC__
#include <stdlib.h>
#else
#include <malloc.h>
#define alloca _alloca
#endif
static const char *ng0 = "//psf/Home/Desktop/3(true test)/2/main_test.vhd";
extern char *STD_TEXTIO;
extern char *IEEE_P_3564397177;

void ieee_p_3564397177_sub_2889341154_91900896(char *, char *, char *, char *, char *);


static void work_a_1919348379_2372691052_p_0(char *t0)
{
    char t6[16];
    char *t1;
    char *t2;
    int64 t3;
    char *t4;
    char *t5;
    char *t7;
    char *t8;
    int t9;
    unsigned int t10;
    unsigned char t11;
    unsigned char t12;
    unsigned int t13;
    unsigned int t14;
    char *t15;
    char *t16;
    unsigned char t17;
    unsigned char t18;
    unsigned char t19;
    unsigned char t20;
    unsigned char t21;
    int t22;
    unsigned int t23;
    unsigned int t24;
    unsigned int t25;
    unsigned char t26;
    unsigned char t27;
    unsigned char t28;
    char *t29;
    int t30;
    unsigned int t31;
    unsigned int t32;
    unsigned int t33;
    unsigned char t34;
    char *t35;
    char *t36;
    unsigned char t37;
    unsigned char t38;
    char *t39;
    int t40;
    unsigned int t41;
    unsigned int t42;
    unsigned int t43;
    unsigned char t44;
    char *t45;
    char *t46;
    unsigned char t47;
    unsigned char t48;
    char *t49;
    int t50;
    unsigned int t51;
    unsigned int t52;
    unsigned int t53;
    unsigned char t54;
    char *t55;
    char *t56;
    unsigned char t57;
    unsigned char t58;

LAB0:    t1 = (t0 + 6768U);
    t2 = *((char **)t1);
    if (t2 == 0)
        goto LAB2;

LAB3:    goto *t2;

LAB2:    xsi_set_current_line(138, ng0);
    t3 = (2.5000000000000000 * 1000LL);
    t2 = (t0 + 6576);
    xsi_process_wait(t2, t3);

LAB6:    *((char **)t1) = &&LAB7;

LAB1:    return;
LAB4:    xsi_set_current_line(143, ng0);
    t2 = (t0 + 5936U);
    t4 = (t0 + 11714);
    t7 = (t6 + 0U);
    t8 = (t7 + 0U);
    *((int *)t8) = 1;
    t8 = (t7 + 4U);
    *((int *)t8) = 18;
    t8 = (t7 + 8U);
    *((int *)t8) = 1;
    t9 = (18 - 1);
    t10 = (t9 * 1);
    t10 = (t10 + 1);
    t8 = (t7 + 12U);
    *((unsigned int *)t8) = t10;
    std_textio_file_open1(t2, t4, t6, (unsigned char)0);
    xsi_set_current_line(145, ng0);

LAB8:    t2 = (t0 + 5936U);
    t11 = std_textio_endfile(t2);
    t12 = (!(t11));
    if (t12 != 0)
        goto LAB9;

LAB11:    xsi_set_current_line(185, ng0);
    t2 = (t0 + 5936U);
    std_textio_file_close(t2);
    xsi_set_current_line(186, ng0);
    t2 = (t0 + 4528U);
    t4 = *((char **)t2);
    t11 = *((unsigned char *)t4);
    t12 = (!(t11));
    if (t12 != 0)
        goto LAB35;

LAB37:
LAB36:    xsi_set_current_line(190, ng0);
    if ((unsigned char)0 == 0)
        goto LAB38;

LAB39:    goto LAB2;

LAB5:    goto LAB4;

LAB7:    goto LAB5;

LAB9:    xsi_set_current_line(146, ng0);
    t4 = (t0 + 6576);
    t5 = (t0 + 5936U);
    t7 = (t0 + 6112U);
    std_textio_readline(STD_TEXTIO, t4, t5, t7);
    xsi_set_current_line(147, ng0);
    t2 = (t0 + 6576);
    t4 = (t0 + 6112U);
    t5 = (t0 + 4288U);
    t7 = *((char **)t5);
    t5 = (t0 + 11512U);
    ieee_p_3564397177_sub_2889341154_91900896(IEEE_P_3564397177, t2, t4, t7, t5);
    xsi_set_current_line(148, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (12 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7152);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(150, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (11 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7216);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(152, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (10 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7280);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(153, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (9 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7344);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(154, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (8 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7408);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(156, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (7 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7472);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(157, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (6 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7536);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(159, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (5 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7600);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(160, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (4 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7664);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(161, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (3 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7728);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(162, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (2 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7792);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(164, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (1 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7856);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(165, ng0);
    t2 = (t0 + 4288U);
    t4 = *((char **)t2);
    t9 = (0 - 12);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t11 = *((unsigned char *)t2);
    t5 = (t0 + 7920);
    t7 = (t5 + 56U);
    t8 = *((char **)t7);
    t15 = (t8 + 56U);
    t16 = *((char **)t15);
    *((unsigned char *)t16) = t11;
    xsi_driver_first_trans_fast(t5);
    xsi_set_current_line(166, ng0);
    t3 = (1 * 1000LL);
    t2 = (t0 + 6576);
    xsi_process_wait(t2, t3);

LAB14:    *((char **)t1) = &&LAB15;
    goto LAB1;

LAB10:;
LAB12:    xsi_set_current_line(168, ng0);
    t2 = (t0 + 6576);
    t4 = (t0 + 5936U);
    t5 = (t0 + 6112U);
    std_textio_readline(STD_TEXTIO, t2, t4, t5);
    xsi_set_current_line(169, ng0);
    t2 = (t0 + 6576);
    t4 = (t0 + 6112U);
    t5 = (t0 + 4408U);
    t7 = *((char **)t5);
    t5 = (t0 + 11528U);
    ieee_p_3564397177_sub_2889341154_91900896(IEEE_P_3564397177, t2, t4, t7, t5);
    xsi_set_current_line(171, ng0);
    t2 = (t0 + 4408U);
    t4 = *((char **)t2);
    t9 = (4 - 4);
    t10 = (t9 * -1);
    t13 = (1U * t10);
    t14 = (0 + t13);
    t2 = (t4 + t14);
    t19 = *((unsigned char *)t2);
    t5 = (t0 + 3752U);
    t7 = *((char **)t5);
    t20 = *((unsigned char *)t7);
    t21 = (t19 != t20);
    if (t21 == 1)
        goto LAB28;

LAB29:    t5 = (t0 + 4408U);
    t8 = *((char **)t5);
    t22 = (3 - 4);
    t23 = (t22 * -1);
    t24 = (1U * t23);
    t25 = (0 + t24);
    t5 = (t8 + t25);
    t26 = *((unsigned char *)t5);
    t15 = (t0 + 3592U);
    t16 = *((char **)t15);
    t27 = *((unsigned char *)t16);
    t28 = (t26 != t27);
    t18 = t28;

LAB30:    if (t18 == 1)
        goto LAB25;

LAB26:    t15 = (t0 + 4408U);
    t29 = *((char **)t15);
    t30 = (2 - 4);
    t31 = (t30 * -1);
    t32 = (1U * t31);
    t33 = (0 + t32);
    t15 = (t29 + t33);
    t34 = *((unsigned char *)t15);
    t35 = (t0 + 3432U);
    t36 = *((char **)t35);
    t37 = *((unsigned char *)t36);
    t38 = (t34 != t37);
    t17 = t38;

LAB27:    if (t17 == 1)
        goto LAB22;

LAB23:    t35 = (t0 + 4408U);
    t39 = *((char **)t35);
    t40 = (1 - 4);
    t41 = (t40 * -1);
    t42 = (1U * t41);
    t43 = (0 + t42);
    t35 = (t39 + t43);
    t44 = *((unsigned char *)t35);
    t45 = (t0 + 3272U);
    t46 = *((char **)t45);
    t47 = *((unsigned char *)t46);
    t48 = (t44 != t47);
    t12 = t48;

LAB24:    if (t12 == 1)
        goto LAB19;

LAB20:    t45 = (t0 + 4408U);
    t49 = *((char **)t45);
    t50 = (0 - 4);
    t51 = (t50 * -1);
    t52 = (1U * t51);
    t53 = (0 + t52);
    t45 = (t49 + t53);
    t54 = *((unsigned char *)t45);
    t55 = (t0 + 3112U);
    t56 = *((char **)t55);
    t57 = *((unsigned char *)t56);
    t58 = (t54 != t57);
    t11 = t58;

LAB21:    if (t11 != 0)
        goto LAB16;

LAB18:
LAB17:    xsi_set_current_line(180, ng0);
    t3 = (1.5000000000000000 * 1000LL);
    t2 = (t0 + 6576);
    xsi_process_wait(t2, t3);

LAB33:    *((char **)t1) = &&LAB34;
    goto LAB1;

LAB13:    goto LAB12;

LAB15:    goto LAB13;

LAB16:    xsi_set_current_line(176, ng0);
    t55 = (t0 + 11732);
    xsi_report(t55, 15U, 0);
    xsi_set_current_line(177, ng0);
    t2 = (t0 + 4528U);
    t4 = *((char **)t2);
    t2 = (t4 + 0);
    *((unsigned char *)t2) = (unsigned char)1;
    goto LAB17;

LAB19:    t11 = (unsigned char)1;
    goto LAB21;

LAB22:    t12 = (unsigned char)1;
    goto LAB24;

LAB25:    t17 = (unsigned char)1;
    goto LAB27;

LAB28:    t18 = (unsigned char)1;
    goto LAB30;

LAB31:    goto LAB8;

LAB32:    goto LAB31;

LAB34:    goto LAB32;

LAB35:    xsi_set_current_line(187, ng0);
    t2 = (t0 + 11747);
    xsi_report(t2, 10U, 0);
    goto LAB36;

LAB38:    t2 = (t0 + 11757);
    xsi_report(t2, 32U, (unsigned char)3);
    goto LAB39;

}


extern void work_a_1919348379_2372691052_init()
{
	static char *pe[] = {(void *)work_a_1919348379_2372691052_p_0};
	xsi_register_didat("work_a_1919348379_2372691052", "isim/main_test_isim_beh.exe.sim/work/a_1919348379_2372691052.didat");
	xsi_register_executes(pe);
}
