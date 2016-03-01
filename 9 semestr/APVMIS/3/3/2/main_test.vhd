--------------------------------------------------------------------------------
-- Company: 
-- Engineer:
--
-- Create Date:   17:46:13 10/05/2015
-- Design Name:   
-- Module Name:   Y:/Desktop/2/laba2/main_test.vhd
-- Project Name:  laba2
-- Target Device:  
-- Tool versions:  
-- Description:   
-- 
-- VHDL Test Bench Created by ISE for module: main
-- 
-- Dependencies:
-- 
-- Revision:
-- Revision 0.01 - File Created
-- Additional Comments:
--
-- Notes: 
-- This testbench has been automatically generated using types std_logic and
-- std_logic_vector for the ports of the unit under test.  Xilinx recommends
-- that these types always be used for the top-level I/O of a design in order
-- to guarantee that the testbench will bind correctly to the post-implementation 
-- simulation model.
--------------------------------------------------------------------------------
LIBRARY ieee;
USE ieee.std_logic_1164.ALL;
USE ieee.numeric_std.ALL;
USE ieee.std_logic_textio.ALL;
LIBRARY std;
USE std.textio.ALL;
 
-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--USE ieee.numeric_std.ALL;
 
ENTITY main_test IS
END main_test;
 
ARCHITECTURE behavior OF main_test IS 
 
    -- Component Declaration for the Unit Under Test (UUT)
 
    COMPONENT main
    PORT(
         G : IN  std_logic;
         R : IN  std_logic;
         RCK : IN  std_logic;
         CCLR : IN  std_logic;
         UP : IN  std_logic;
         LOAD : IN  std_logic;
         ENP : IN  std_logic;
         ENT : IN  std_logic;
         CCK : IN  std_logic;
         A : IN  std_logic;
         B : IN  std_logic;
         C : IN  std_logic;
         D : IN  std_logic;
         Qa : OUT  std_logic;
         Qb : OUT  std_logic;
         Qc : OUT  std_logic;
         Qd : OUT  std_logic;
         RCO : OUT  std_logic
        );
    END COMPONENT;
    

   --Inputs
   signal G : std_logic := '0';
   signal R : std_logic := '0';
   signal RCK : std_logic := '0';
   signal CCLR : std_logic := '0';
   signal UP : std_logic := '0';
   signal LOAD : std_logic := '0';
   signal ENP : std_logic := '0';
   signal ENT : std_logic := '0';
   signal CCK : std_logic := '0';
   signal A : std_logic := '0';
   signal B : std_logic := '0';
   signal C : std_logic := '0';
   signal D : std_logic := '0';

 	--Outputs
   signal Qa : std_logic;
   signal Qb : std_logic;
   signal Qc : std_logic;
   signal Qd : std_logic;
   signal RCO : std_logic;
   -- No clocks detected in port list. Replace <clock> below with 
   -- appropriate port name 
	
	constant CCK_period : time := 5 ns;
	constant RCK_period : time := 5 ns;
	
BEGIN
 
	-- Instantiate the Unit Under Test (UUT)
   uut: main PORT MAP (
          G => G,
          R => R,
          RCK => RCK,
          CCLR => CCLR,
          UP => UP,
          LOAD => LOAD,
          ENP => ENP,
          ENT => ENT,
          CCK => CCK,
          A => A,
          B => B,
          C => C,
          D => D,
          Qa => Qa,
          Qb => Qb,
          Qc => Qc,
          Qd => Qd,
          RCO => RCO
        );
		  
	-- Clock process definitions
   CCK_process :process
   begin
		CCK <= '0';
		wait for CCK_period/2;
		CCK <= '1';
		wait for CCK_period/2;
   end process;
	
   RCK_process :process
   begin
		RCK <= '0';
		wait for RCK_period/2;
		RCK <= '1';
		wait for RCK_period/2;
   end process;
 

   -- Stimulus process
   stim_proc: process
					file file_pointer : text;
					variable current_line : line;
					variable test_input : std_logic_vector(10 downto 0);
					variable test_output: std_logic_vector(4 downto 0);
					variable is_any_error : boolean := false;
					variable previousQa, previousQb, 
								previousQc, previousQd,
								previousCountDirection,
								previousENP, previousENT: std_logic;
					variable temp1, temp2: std_logic_vector(3 downto 0);
   begin
		
		wait for 2.5ns;
		
		-- load 1111 to registers
		
		--loop begin
		file_open(file_pointer, "file_test.txt", READ_MODE);
		
		while not endfile(file_pointer) loop
			readline(file_pointer, current_line);
			read(current_line, test_input);
			G <= test_input(10);
		
			R <= test_input(9);
			
			LOAD <= test_input(8);
			CCLR <= test_input(7);
			UP <= test_input(6);
			
			ENP <= test_input(5);
			ENT <= test_input(4);
			
			A <= test_input(3);
			B <= test_input(2);
			C <= test_input(1);
			D <= test_input(0);
			wait for 1 ns;
			
			previousQa := Qa;
			previousQb := Qb;
			previousQc := Qc;
			previousQd := Qd;
			
			previousCountDirection := UP;
			previousENP := ENP;
			previousENT := ENT;
			
			if ((LOAD='0') and (R='1') and (G='0') and (CCLR='1')) then
				wait for 2*RCK_period; -- 2 periods
			end if;
			
			readline(file_pointer, current_line);
			read(current_line, test_output);

			if (G='1' and
					 (Qa /= 'Z' or 
					 Qb /= 'Z' or
					 Qc /= 'Z' or
					 Qd /= 'Z')) then
				report "Error in G";
				is_any_error := true;
			elsif (CCLR='0' and
					 (Qa /= '0' or 
					 Qb /= '0' or
					 Qc /= '0' or
					 Qd /= '0')) then
				report "Error in CCLR";
				is_any_error := true;
			elsif (R = '0' and ((UP = '0' and RCO /= '0' and
					 Qa = '0' and 
					 Qb = '0' and
					 Qc = '0' and
					 Qd = '0') or 
					 (UP = '1' and RCO /= '0' and
					 Qa = '1' and 
					 Qb = '1' and
					 Qc = '1' and
					 Qd = '1'))) then
				report "Error in RCO";
				is_any_error := true;
			elsif (LOAD='0' and R='1' and
				 (test_output(0) /= Qa or 
				 test_output(1) /= Qb or
				 test_output(2) /= Qc or
				 test_output(3) /= Qd)) then
				report "Error in test #";
				is_any_error := true;
			elsif (R='0' and UP='0' and (UP /= previousCountDirection)) then
				temp1(0) := previousQa;
				temp1(1) := previousQb;
				temp1(2) := previousQc;
				temp1(3) := previousQd;
				
				temp2(0) := Qa;
				temp2(1) := Qb;
				temp2(2) := Qc;
				temp2(3) := Qd;
				if (std_logic_vector(Unsigned(temp1)-1) /= temp2) then 
					report "Error in test #";
					is_any_error := true;
				end if;
			elsif (R='0' and UP='1' and (UP /= previousCountDirection)) then
				temp1(0) := previousQa;
				temp1(1) := previousQb;
				temp1(2) := previousQc;
				temp1(3) := previousQd;
				
				temp2(0) := Qa;
				temp2(1) := Qb;
				temp2(2) := Qc;
				temp2(3) := Qd;
				if (std_logic_vector(Unsigned(temp1)+1) /= temp2) then 
					report "Error in test #";
					is_any_error := true;
				end if;
			elsif (ENP='1' and R='0' and (ENP /= previousENP)) then
				if (previousQa /= Qa or
					 previousQb /= Qb or
					 previousQc /= Qc or
					 previousQd /= Qd) then 
					report "Error in test #";
					is_any_error := true;
				end if;
			elsif (ENT='1' and R='0' and (ENT /= previousENT)) then
				if (previousQa /= Qa or
					 previousQb /= Qb or
					 previousQc /= Qc or
					 previousQd /= Qd) then 
					report "Error in test #";
					is_any_error := true;
				end if;
			end if;
			
			if (R='0') then
				wait for CCK_period - 1 ns;
			else
				wait for RCK_period - 1 ns;
			end if;
			
		end loop;
		

		file_close(file_pointer);
		if not is_any_error then
			report "No errors!";
		end if;
		
		assert false report "MY INTERRUPT. End of simulation." severity failure;

   end process;

END;
