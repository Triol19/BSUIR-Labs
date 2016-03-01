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
static const char *ng0 = "//psf/Home/Desktop/3/1/mux_test2.vhd";
extern char *STD_TEXTIO;
extern char *IEEE_P_3564397177;
extern char *STD_STANDARD;

void ieee_p_3564397177_sub_2889341154_91900896(char *, char *, char *, char *, char *);


static void work_a_0318312823_2372691052_p_0(char *t0)
{
    char t5[16];
    char t21[16];
    char t23[16];
    char *t1;
    char *t2;
    char *t3;
    char *t4;
    char *t6;
    char *t7;
    int t8;
    unsigned int t9;
    unsigned char t10;
    unsigned char t11;
    unsigned int t12;
    unsigned int t13;
    char *t14;
    char *t15;
    int64 t16;
    unsigned char t17;
    unsigned char t18;
    char *t19;
    char *t20;
    char *t22;
    char *t24;
    char *t25;
    int t26;

LAB0:    t1 = (t0 + 3528U);
    t2 = *((char **)t1);
    if (t2 == 0)
        goto LAB2;

LAB3:    goto *t2;

LAB2:    xsi_set_current_line(99, ng0);
    t2 = (t0 + 2696U);
    t3 = (t0 + 6489);
    t6 = (t5 + 0U);
    t7 = (t6 + 0U);
    *((int *)t7) = 1;
    t7 = (t6 + 4U);
    *((int *)t7) = 17;
    t7 = (t6 + 8U);
    *((int *)t7) = 1;
    t8 = (17 - 1);
    t9 = (t8 * 1);
    t9 = (t9 + 1);
    t7 = (t6 + 12U);
    *((unsigned int *)t7) = t9;
    std_textio_file_open1(t2, t3, t5, (unsigned char)0);
    xsi_set_current_line(101, ng0);

LAB4:    t2 = (t0 + 2696U);
    t10 = std_textio_endfile(t2);
    t11 = (!(t10));
    if (t11 != 0)
        goto LAB5;

LAB7:    xsi_set_current_line(121, ng0);
    t2 = (t0 + 2696U);
    std_textio_file_close(t2);
    xsi_set_current_line(123, ng0);
    t2 = (t0 + 2368U);
    t3 = *((char **)t2);
    t10 = *((unsigned char *)t3);
    t11 = (!(t10));
    if (t11 != 0)
        goto LAB15;

LAB17:
LAB16:    xsi_set_current_line(126, ng0);
    if ((unsigned char)0 == 0)
        goto LAB18;

LAB19:    goto LAB2;

LAB5:    xsi_set_current_line(103, ng0);
    t3 = (t0 + 3336);
    t4 = (t0 + 2696U);
    t6 = (t0 + 2872U);
    std_textio_readline(STD_TEXTIO, t3, t4, t6);
    xsi_set_current_line(104, ng0);
    t2 = (t0 + 3336);
    t3 = (t0 + 2872U);
    t4 = (t0 + 2128U);
    t6 = *((char **)t4);
    t4 = (t0 + 6352U);
    ieee_p_3564397177_sub_2889341154_91900896(IEEE_P_3564397177, t2, t3, t6, t4);
    xsi_set_current_line(105, ng0);
    t2 = (t0 + 2128U);
    t3 = *((char **)t2);
    t9 = (10 - 10);
    t12 = (t9 * 1U);
    t13 = (0 + t12);
    t2 = (t3 + t13);
    t4 = (t0 + 3912);
    t6 = (t4 + 56U);
    t7 = *((char **)t6);
    t14 = (t7 + 56U);
    t15 = *((char **)t14);
    memcpy(t15, t2, 3U);
    xsi_driver_first_trans_fast(t4);
    xsi_set_current_line(106, ng0);
    t2 = (t0 + 2128U);
    t3 = *((char **)t2);
    t9 = (10 - 7);
    t12 = (t9 * 1U);
    t13 = (0 + t12);
    t2 = (t3 + t13);
    t4 = (t0 + 3976);
    t6 = (t4 + 56U);
    t7 = *((char **)t6);
    t14 = (t7 + 56U);
    t15 = *((char **)t14);
    memcpy(t15, t2, 8U);
    xsi_driver_first_trans_fast(t4);
    xsi_set_current_line(108, ng0);
    t2 = (t0 + 2128U);
    t3 = *((char **)t2);
    t9 = (10 - 10);
    t12 = (t9 * 1U);
    t13 = (0 + t12);
    t2 = (t3 + t13);
    t4 = (t0 + 4040);
    t6 = (t4 + 56U);
    t7 = *((char **)t6);
    t14 = (t7 + 56U);
    t15 = *((char **)t14);
    memcpy(t15, t2, 3U);
    xsi_driver_first_trans_fast(t4);
    xsi_set_current_line(109, ng0);
    t2 = (t0 + 2128U);
    t3 = *((char **)t2);
    t9 = (10 - 7);
    t12 = (t9 * 1U);
    t13 = (0 + t12);
    t2 = (t3 + t13);
    t4 = (t0 + 4104);
    t6 = (t4 + 56U);
    t7 = *((char **)t6);
    t14 = (t7 + 56U);
    t15 = *((char **)t14);
    memcpy(t15, t2, 8U);
    xsi_driver_first_trans_fast(t4);
    xsi_set_current_line(111, ng0);
    t2 = (t0 + 3336);
    t3 = (t0 + 2696U);
    t4 = (t0 + 2872U);
    std_textio_readline(STD_TEXTIO, t2, t3, t4);
    xsi_set_current_line(113, ng0);
    t16 = (1 * 1000LL);
    t2 = (t0 + 3336);
    xsi_process_wait(t2, t16);

LAB10:    *((char **)t1) = &&LAB11;

LAB1:    return;
LAB6:;
LAB8:    xsi_set_current_line(114, ng0);
    t2 = (t0 + 1672U);
    t3 = *((char **)t2);
    t10 = *((unsigned char *)t3);
    t2 = (t0 + 1832U);
    t4 = *((char **)t2);
    t11 = *((unsigned char *)t4);
    t17 = (t10 == t11);
    t18 = (!(t17));
    if (t18 != 0)
        goto LAB12;

LAB14:
LAB13:    xsi_set_current_line(118, ng0);
    t2 = (t0 + 2248U);
    t3 = *((char **)t2);
    t8 = *((int *)t3);
    t26 = (t8 + 1);
    t2 = (t0 + 2248U);
    t4 = *((char **)t2);
    t2 = (t4 + 0);
    *((int *)t2) = t26;
    goto LAB4;

LAB9:    goto LAB8;

LAB11:    goto LAB9;

LAB12:    xsi_set_current_line(115, ng0);
    t2 = (t0 + 6506);
    t7 = ((STD_STANDARD) + 384);
    t14 = (t0 + 2248U);
    t15 = *((char **)t14);
    t8 = *((int *)t15);
    t14 = xsi_int_to_mem(t8);
    t19 = xsi_string_variable_get_image(t5, t7, t14);
    t22 = ((STD_STANDARD) + 1008);
    t24 = (t23 + 0U);
    t25 = (t24 + 0U);
    *((int *)t25) = 1;
    t25 = (t24 + 4U);
    *((int *)t25) = 15;
    t25 = (t24 + 8U);
    *((int *)t25) = 1;
    t26 = (15 - 1);
    t9 = (t26 * 1);
    t9 = (t9 + 1);
    t25 = (t24 + 12U);
    *((unsigned int *)t25) = t9;
    t20 = xsi_base_array_concat(t20, t21, t22, (char)97, t2, t23, (char)97, t19, t5, (char)101);
    t25 = (t5 + 12U);
    t9 = *((unsigned int *)t25);
    t12 = (15U + t9);
    xsi_report(t20, t12, 0);
    xsi_set_current_line(116, ng0);
    t2 = (t0 + 2368U);
    t3 = *((char **)t2);
    t2 = (t3 + 0);
    *((unsigned char *)t2) = (unsigned char)1;
    goto LAB13;

LAB15:    xsi_set_current_line(124, ng0);
    t2 = (t0 + 6521);
    xsi_report(t2, 10U, 0);
    goto LAB16;

LAB18:    t2 = (t0 + 6531);
    xsi_report(t2, 32U, (unsigned char)3);
    goto LAB19;

}


extern void work_a_0318312823_2372691052_init()
{
	static char *pe[] = {(void *)work_a_0318312823_2372691052_p_0};
	xsi_register_didat("work_a_0318312823_2372691052", "isim/mux_test2_isim_beh.exe.sim/work/a_0318312823_2372691052.didat");
	xsi_register_executes(pe);
}
