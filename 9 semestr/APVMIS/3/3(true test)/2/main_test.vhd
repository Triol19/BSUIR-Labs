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
		  
	-- Clock process definition
 

   -- Stimulus process
   stim_proc: process
					file file_pointer : text;
					variable current_line : line;
					variable test_input : std_logic_vector(12 downto 0);
					variable test_output: std_logic_vector(4 downto 0);
					variable is_any_error : boolean := false;
					variable previousQa, previousQb, 
								previousQc, previousQd,
								previousCountDirection,
								previousENP, previousENT: std_logic;
					variable temp1, temp2: std_logic_vector(3 downto 0);
   begin
		
		wait for 2.5 ns;
		
		-- load 1111 to registers
		
		--loop begin
		file_open(file_pointer, "file_test_todo.txt", READ_MODE);
		
		while not endfile(file_pointer) loop
			readline(file_pointer, current_line);
			read(current_line, test_input);
			G <= test_input(12);
		
			R <= test_input(11);
			
			CCLR <= test_input(10);
			UP <= test_input(9);
			LOAD <= test_input(8);
			
			ENP <= test_input(7);
			ENT <= test_input(6);
			
			A <= test_input(5);
			B <= test_input(4);
			C <= test_input(3);
			D <= test_input(2);
			
			RCK <= test_input(1);
			CCK <= test_input(0);
			wait for 1 ns;
			
			readline(file_pointer, current_line);
			read(current_line, test_output);

			if (test_output(4) /= RCO or
				 test_output(3) /= Qd or
				 test_output(2) /= Qc or
				 test_output(1) /= Qb or
				 test_output(0) /= Qa) then
					report "Error in test #";
					is_any_error := true;
			end if;
			
			wait for 1.5 ns;
	
		end loop;
		

		file_close(file_pointer);
		if not is_any_error then
			report "No errors!";
		end if;
		
		assert false report "MY INTERRUPT. End of simulation." severity failure;

   end process;

END;
