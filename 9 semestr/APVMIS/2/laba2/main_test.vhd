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
		variable count: std_logic_vector(14 downto 0) := (others => '0');
   begin		
      -- hold reset state for 100 ns.
      wait for 5 ns;	

      --count := std_logic_vector(Unsigned(count)+1);
		
		wait for 5ns;
		
		-- load 1111 to registers
		
		G <= '0';
		
		R <= '1';
		
		LOAD <= '1';
		CCLR <= '1';
		UP <= '1';
		
		ENP <= '1';
		ENT <= '1';
		
		A <= '1';
		B <= '1';
		C <= '1';
		D <= '1';
		
		wait for 5ns;
		
		LOAD <= '0';
		
		wait for 5ns;
		
		LOAD <= '1';
		
		wait for 10ns;
		
		-- load 0101 to registers
		
		LOAD <= '0';
		
		A <= '0';
		B <= '1';
		C <= '0';
		D <= '1';
		
		wait for 5ns;
		LOAD <= '1';
		wait for 5ns;
		
		-- begin UP count
		R <= '0';
		
		LOAD <= '1';
		
		ENP <= '0';
		ENT <= '0';
		wait for 20ns;
		
		-- begin DOWN count
		
		UP <= '0';
		wait for 30ns;
		
		
		-- turn off outputs
		G <= '1';
		
		wait for 10ns;
		
		-- turn on outputs
		G <= '0';
		wait for 20ns;
		
		-- clear and start up count
		
		CCLR <= '0';
		wait for 5ns;
		UP <= '1';
		CCLR <= '1';
		
		wait for 20ns;
		ENP <= '1';
		
		wait for 20ns;
		ENP <= '0';
		
		wait;

      -- insert stimulus here 

   end process;

END;
