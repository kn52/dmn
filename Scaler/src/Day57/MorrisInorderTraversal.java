package Day57;

import java.util.*;

public class MorrisInorderTraversal {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public ArrayList<Integer> solve(TreeNode A) {
        ArrayList<Integer> ans=new ArrayList<>();
        TreeNode cur=A;
        while(cur!=null){
            if(cur.left==null){
                ans.add(cur.val);
                cur=cur.right;
            }
            else{
                TreeNode temp=cur.left;
                while(temp.right!=null && temp.right!=cur){
                    temp=temp.right;
                }
                if(temp.right==null) {
                    temp.right=cur;
                    cur=cur.left;
                }
                else{
                    temp.right=null;
                    ans.add(cur.val);
                    cur=cur.right;
                }
            }
        }
        return ans;
    }
}
