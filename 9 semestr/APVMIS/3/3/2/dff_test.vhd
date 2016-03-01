--------------------------------------------------------------------------------
-- Company: 
-- Engineer:
--
-- Create Date:   16:44:28 10/04/2015
-- Design Name:   
-- Module Name:   Y:/Desktop/2/laba2/dff_test.vhd
-- Project Name:  laba2
-- Target Device:  
-- Tool versions:  
-- Description:   
-- 
-- VHDL Test Bench Created by ISE for module: dff
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
 
-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--USE ieee.numeric_std.ALL;
 
ENTITY dff_test IS
END dff_test;
 
ARCHITECTURE behavior OF dff_test IS 
 
    -- Component Declaration for the Unit Under Test (UUT)
 
    COMPONENT dff
    PORT(
         S : IN  std_logic;
         R : IN  std_logic;
         D : IN  std_logic;
         C : IN  std_logic;
         Q : OUT  std_logic;
         NQ : OUT  std_logic
        );
    END COMPONENT;
    

   --Inputs
   signal S : std_logic := '1';
   signal R : std_logic := '1';
   signal D : std_logic := '1';
   signal C : std_logic := '0';

 	--Outputs
   signal Q : std_logic;
   signal NQ : std_logic;
   -- No clocks detected in port list. Replace <clock> below with 
   -- appropriate port name 
 
   constant C_period : time := 10 ns;
 
BEGIN
 
	-- Instantiate the Unit Under Test (UUT)
   uut: dff PORT MAP (
          S => S,
          R => R,
          D => D,
          C => C,
          Q => Q,
          NQ => NQ
        );

   -- Clock process definitions
   C_process :process
   begin
		C <= '0';
		wait for C_period/2;
		C <= '1';
		wait for C_period/2;
   end process;
 

   -- Stimulus process
   stim_proc: process
   begin		
      -- hold reset state for 100 ns.
      wait for 100 ns;	

      -- insert stimulus here 
		WAIT FOR C_period;
		R <= '0';
		WAIT FOR C_period;
		R <= '1';
		WAIT FOR C_period;
		D <= '0';
		WAIT FOR C_period;
		S <= '0';
		WAIT FOR C_period;
		S <= '1';
		WAIT FOR C_period;
		D <= '1';
		WAIT FOR C_period;
		D <= '0';
		WAIT FOR C_period;



		  
        wait;
   end process;

END;
